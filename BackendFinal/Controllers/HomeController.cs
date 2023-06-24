using BackendFinal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BackendFinal.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

       
    }
}