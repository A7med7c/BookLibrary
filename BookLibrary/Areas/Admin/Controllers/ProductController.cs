using BookLibrary.BL.Models;
using BookLibrary.BL.View_Model;
using BookLibrary.DataAcess.Data;
using BookLibrary.DataAcess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json.Serialization;
using System.Text.Json;
namespace BookLibraryWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IUnitOfWork unitOfWork,IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            // List<Product> objProductList = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
            List<Product> ProductList = _unitOfWork.Product.productsWithCategory().ToList();

            return View(ProductList);
        }
        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new()
            {
                CategoriesList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.CategoryId.ToString()
                }),
                Product = new Product()
            };
            if (id == null || id == 0)
            {
                //create
                return View(productVM);
            }
            else
            {
                //update 
              productVM.Product = _unitOfWork.Product.Get(u => u.ProductId == id);
                return View( productVM);
            }
        }

        [HttpPost]
        public IActionResult Upsert(ProductVM productVM , IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if(file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"Images\Product");

                    if (!string.IsNullOrEmpty(productVM.Product.ImageUrl))
                    {
                        //delete old image 
                        var oldImagePath = Path.Combine(wwwRootPath,productVM.Product.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                using(var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                productVM.Product.ImageUrl = @"\Images\Product\" + fileName;
                }

                //handel add 
                if (productVM.Product.ProductId == 0)
                {
                    _unitOfWork.Product.Add(productVM.Product);
                    TempData["sucess"] = "Product Created Successfully";

                }
                else
                {
                    _unitOfWork.Product.Update(productVM.Product);
                    TempData["sucess"] = "Product Updated Successfully";

                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                productVM.CategoriesList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.CategoryId.ToString()
                });
                return View( productVM);
            }
        }

     
        //[HttpGet]
        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }

        //    Product productfromDB = _unitOfWork.Product.Get(c => c.ProductId == id);

        //    if (productfromDB == null)
        //    {
        //        return NotFound();
        //    }

        //    return View( productfromDB);
        //}

        //[HttpPost]
        //[ActionName("Delete")]
        //public IActionResult DeletePost(int? id)
        //{
        //    Product product = _unitOfWork.Product.Get(c => c.ProductId == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    _unitOfWork.Product.Remove(product);
        //    _unitOfWork.Save();
        //    TempData["sucess"] = "Product Deleted Successfully";
        //    return RedirectToAction(nameof(Index));
        //}

        #region API Calls
        [HttpGet]
        public IActionResult GetAll()
        {
           // List<Product> objProductList = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();

            List<Product> ProductList = _unitOfWork.Product.productsWithCategory().ToList();
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true // Optional: for pretty-printing the JSON
            };
            return Json(new { data = ProductList }, options);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            // List<Product> objProductList = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();

            var productToBeDeleted = _unitOfWork.Product.Get(c => c.ProductId == id);
            if(productToBeDeleted == null)
            {
                return Json(new { sucess = false, message = "Error while deleting" });
            }
            string wwwRootPath = _webHostEnvironment.WebRootPath;


            var oldImagePath = Path.Combine(wwwRootPath, productToBeDeleted.ImageUrl.TrimStart('\\'));

            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _unitOfWork.Product.Remove(productToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successfuly" });

        }

        #endregion
    }
}
