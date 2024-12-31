using BookLibrary.BL.Models;
using BookLibrary.DataAcess.Data;
using BookLibrary.DataAcess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Product> products = _unitOfWork.Product.GetAll().ToList();
            return View("Index",products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(product);
                _unitOfWork.Save();
                TempData["sucess"] = "Product Created Successfully";
                return RedirectToAction("Index");
            }
            return View("Create", product);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product productfromDB = _unitOfWork.Product.Get(c => c.ProductId == id);
            if (productfromDB == null)
            {
                return NotFound();
            }
            return View("Edit", productfromDB);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(product);
                _unitOfWork.Save();
                TempData["sucess"] = "Product Updated Successfully";
                return RedirectToAction("Index");
            }
            return View("Edit", product);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Product productfromDB = _unitOfWork.Product.Get(c => c.ProductId == id);

            if (productfromDB == null)
            {
                return NotFound();
            }

            return View("Delete", productfromDB);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Product product = _unitOfWork.Product.Get(c => c.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(product);
            _unitOfWork.Save();
            TempData["sucess"] = "Product Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
