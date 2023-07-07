using BackendFinal.DAL;
using BackendFinal.Models;
using BackendFinal.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BackendFinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public HomeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM();
            homeVM.Sliders = _appDbContext.Sliders.ToList();
            homeVM.Banners = _appDbContext.Banners.ToList();
            homeVM.Bios = _appDbContext.Bios.FirstOrDefault();
            homeVM.Products = _appDbContext.Products.Include(p => p.Images).Include(p => p.Category).ToList();
            return View(homeVM);
        }
        public IActionResult Search(string search)
        {
            var products = _appDbContext.Products.Include(p => p.Images).Include(p => p.Category)
                .Where(p => p.Name.ToLower().Contains(search.ToLower()))
                .Take(3)
                .OrderByDescending(p => p.Id)
                .ToList();
            return PartialView("_SearchPartial", products);
        }

    }
}