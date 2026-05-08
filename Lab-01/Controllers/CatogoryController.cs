using Microsoft.AspNetCore.Mvc;

namespace Lab_01.Controllers
{
    public class CatogoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
