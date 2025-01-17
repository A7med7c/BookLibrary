using Microsoft.AspNetCore.Mvc;

namespace BookLibraryWeb.Areas.Customer
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
