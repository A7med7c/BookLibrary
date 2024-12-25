using BookLibraryWeb.Data;
using BookLibraryWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext context;

        public CategoryController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Category> categories = context.Categories.ToList();
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
                context.Categories.Add(obj);    
                context.SaveChanges();
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
            Category categoryfromDb = context.Categories.FirstOrDefault(c=>c.CategoryId == id);
            if (categoryfromDb == null) 
            {
                return NotFound();
            }
            return View("Edit", categoryfromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj , int id)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Update(obj);
                context.SaveChanges();
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
            Category categoryfromDb = context.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (categoryfromDb == null)
            {
                return NotFound();
            }
            return View("Delete", categoryfromDb);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category obj = context.Categories.FirstOrDefault(e=>e.CategoryId == id);
            if (obj == null)
            {
                return NotFound();
            }
            context.Categories.Remove(obj);
            context.SaveChanges();
            TempData["sucess"] = "Category Deleted Successfully";

            return RedirectToAction("Index");
        }


    }
}
