using BackendFinal.DAL;
using BackendFinal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BackendFinal.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public CategoryController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            return View(_appDbContext.Categories.ToList());
        }
        public IActionResult Create()
        {
            ViewBag.Categories = _appDbContext.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            ViewBag.Categories = _appDbContext.Categories.ToList();
            if (!ModelState.IsValid) return View();
            _appDbContext.Categories.Add(category);
            _appDbContext.SaveChanges();    
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (!ModelState.IsValid) return View();
            if (id == null) return View();
            var exist = _appDbContext.Categories.FirstOrDefault(c => c.Id == id);
            if (exist == null) return View();
            _appDbContext.Categories.Remove(exist);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
