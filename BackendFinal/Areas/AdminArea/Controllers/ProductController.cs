using Microsoft.AspNetCore.Mvc;

namespace BackendFinal.Areas.AdminArea.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(object obj)
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(object obj)
        {
            return View();
        }
    }
}
