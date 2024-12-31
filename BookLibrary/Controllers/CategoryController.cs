using BookLibrary.BL.Models;
using BookLibrary.DataAcess.Data;
using BookLibrary.DataAcess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository categoryRepo;

        public CategoryController(ICategoryRepository context)
        {
           categoryRepo = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Category> categories = categoryRepo.GetAll().ToList();
            return View("Index",categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                categoryRepo.Add(obj);
                categoryRepo.Save();    
                TempData["sucess"] = "Category Created Successfully"; 

                return RedirectToAction("Index");
            }
            return View("Create",obj);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();  
            }
            Category categoryfromDb = categoryRepo.Get(c=>c.CategoryId == id);
            if (categoryfromDb == null) 
            {
                return NotFound();
            }
            return View("Edit", categoryfromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
          
            if (ModelState.IsValid)
            {
                categoryRepo.Update(obj);
                categoryRepo.Save();
                TempData["sucess"] = "Category Updated Successfully";

                return RedirectToAction("Index");
            }
            return View("Edit", obj);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category categoryfromDb = categoryRepo.Get(c => c.CategoryId == id);
            if (categoryfromDb == null)
            {
                return NotFound();
            }
            return View("Delete", categoryfromDb);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category obj = categoryRepo.Get(e=>e.CategoryId == id);
            if (obj == null)
            {
                return NotFound();
            }
            categoryRepo.Remove(obj);
            categoryRepo.Save();
            TempData["sucess"] = "Category Deleted Successfully";

            return RedirectToAction("Index");
        }


    }
}
