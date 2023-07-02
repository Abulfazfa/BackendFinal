using BackendFinal.DAL;
using BackendFinal.Models;
using BackendFinal.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BackendFinal.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public ContactController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            ViewBag.Bio = _appDbContext.Bios.FirstOrDefault();
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Index(ContactVM contactVM)
        {
            ViewBag.Bio = _appDbContext.Bios.FirstOrDefault();
            if (!ModelState.IsValid) return View();
            UserMessage userMessage = new UserMessage()
            {
                Name = contactVM.Name,
                Email = contactVM.Email,
                Subject = contactVM.Subject,
                Message = contactVM.Message,
            };
            _appDbContext.UserMessages.Add(userMessage);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
