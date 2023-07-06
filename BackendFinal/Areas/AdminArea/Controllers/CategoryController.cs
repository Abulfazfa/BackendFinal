using BackendFinal.DAL;
using BackendFinal.Models;
using BackendFinal.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Linq;

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
            ViewBag.Categories = new SelectList(_appDbContext.Categories.ToList(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(CategoryVM categoryVM)
        {
            ViewBag.Categories = new SelectList(_appDbContext.Categories.ToList(), "Id", "Name");
            if (!ModelState.IsValid) return View();
            Category category = new()
            {
                Name = categoryVM.Name,
                IsMain = categoryVM.IsMain,
                ParentId = categoryVM.ParentId,
            };

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
        public IActionResult Update(int? id)
        {
            var exist = _appDbContext.Categories.FirstOrDefault(c => c.Id == id);
            ViewBag.Categories = new SelectList(_appDbContext.Categories.Where(c => c.Id != id).ToList(), "Id", "Name");
            CategoryVM categoryVM = new CategoryVM
            {
                Name = exist.Name,
                ParentId = exist.ParentId,
                IsMain = exist.IsMain
            };
            return View(categoryVM);

        }
        [HttpPost]
        public IActionResult Update(int? id, CategoryVM categoryVM)
        {
            ViewBag.Categories = new SelectList(_appDbContext.Categories.Where(c => c.Id != id).ToList(), "Id", "Name");
            if (!ModelState.IsValid) return View();
            if(id == null) return View();
            var exist = _appDbContext.Categories.FirstOrDefault(c => c.Id == id);
            if(exist == null) return View();

            exist.Name = categoryVM.Name;
            exist.IsMain = categoryVM.IsMain;
            exist.ParentId = categoryVM.ParentId;
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
