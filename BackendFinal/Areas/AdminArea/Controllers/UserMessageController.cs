using BackendFinal.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;

namespace BackendFinal.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "Admin")]
    public class UserMessageController : Controller
    {
        private readonly AppDbContext _appDbContext;
        
        public UserMessageController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            return View(_appDbContext.UserMessages.Where(m=> m.IsSeen == false).ToList());
        }

        public IActionResult SeenMessage()
        {
            return View(_appDbContext.UserMessages.Where(m => m.IsSeen == true).ToList());
        }
        public IActionResult Seen(int? id)
        {
            if (id == null) return NotFound();
            var message = _appDbContext.UserMessages.FirstOrDefault(x => x.Id == id);
            if (message == null) return NotFound();

            message.IsSeen = true;
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Detail(int? id)
        {
            if (id == null) return NotFound();
            var message = _appDbContext.UserMessages.FirstOrDefault(x => x.Id == id);
            if (message == null) return NotFound();

            return View(message);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var message = _appDbContext.UserMessages.FirstOrDefault(x => x.Id == id);
            if (message == null) return NotFound();

            _appDbContext.UserMessages.Remove(message);
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
