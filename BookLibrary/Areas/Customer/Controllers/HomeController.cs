using BookLibrary.BL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BookLibrary.DataAcess.Repository.IRepository;
using X.PagedList;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using BookLibrary.Utility;

namespace BookLibraryWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(int? page, string searchTerm)
        {
            int pageSize = 8; // Number of items per page
            int pageNumber = page ?? 1; // Default to page 1 if no page is specified

            IEnumerable<Product> products;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                // Filter products based on the search term
                products = _unitOfWork.Product.GetAll(
                    filter: p => p.Title.Contains(searchTerm) || p.Author.Contains(searchTerm),
                    includeProperties: "Category"
                );
            }
            else
            {
                // Get all products if no search term is provided
                products = _unitOfWork.Product.GetAll(includeProperties: "Category");
            }

            // Paginate the products
            var pagedProducts = products.ToPagedList(pageNumber, pageSize);

            // Pass the search term to the view to preserve it in the search box
            ViewBag.SearchTerm = searchTerm;

            return View(pagedProducts);
        }

        public IActionResult Details(int id)
        {
            Product product = _unitOfWork.Product.Get(e => e.ProductId == id, includeProperties: "Category,");
            ShoppingCart cart = new()
            {
                Product = product,
                Quantity = 1,
                ProductId = id
            };

            return View(cart);
       
        }


        [HttpPost]
        [Authorize]
        public IActionResult Details(ShoppingCart shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            shoppingCart.ApplicationUserId = userId;

            ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.ApplicationUserId == userId &&
            u.ProductId == shoppingCart.ProductId);

            if (cartFromDb != null)
            {
                // Shopping cart exists, update quantity
                cartFromDb.Quantity += shoppingCart.Quantity;
                _unitOfWork.ShoppingCart.Update(cartFromDb);
            }
            else
            {
                // Ensure Id is not set manually
                shoppingCart.Id = 0; // <-- Prevents EF from using an explicit value
                _unitOfWork.ShoppingCart.Add(shoppingCart);
            }

            _unitOfWork.Save();

            HttpContext.Session.SetInt32(StaticDetails.SessionCart,
            _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId).Count());

            TempData["success"] = "Cart updated successfully";

            return RedirectToAction(nameof(Index));
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}