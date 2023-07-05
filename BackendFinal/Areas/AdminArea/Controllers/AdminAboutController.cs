using BackendFinal.DAL;
using BackendFinal.Helper;
using BackendFinal.Models;
using BackendFinal.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BackendFinal.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "Admin")]
    public class AdminAboutController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public AdminAboutController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            return View(_appDbContext.AboutSections.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(AboutSection aboutSection)
        {
            if (!ModelState.IsValid) return View();
            _appDbContext.AboutSections.Add(aboutSection);
            _appDbContext.SaveChanges();


            return RedirectToAction("Index");

        }
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var section = _appDbContext.AboutSections.FirstOrDefault(x => x.Id == id);
            if (section == null) return NotFound();

            _appDbContext.AboutSections.Remove(section);
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            var section = _appDbContext.AboutSections.FirstOrDefault(x => x.Id == id);
            if (section == null) return NotFound();
            
            return View(section);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(int? id, AboutSection aboutSection)
        {
            var section = _appDbContext.AboutSections.FirstOrDefault(c => c.Id == id);

            section.Title = aboutSection.Title;
            section.Description = aboutSection.Description;
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Detail(int? id)
        {
            if (id == null) return NotFound();
            var section = _appDbContext.AboutSections.FirstOrDefault(x => x.Id == id);
            if (section == null) return NotFound();

            return View(section);
        }
    }
}
