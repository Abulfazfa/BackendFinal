using BackendFinal.DAL;
using BackendFinal.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BackendFinal.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public AboutController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            var bio = _appDbContext.Bios.FirstOrDefault();
            AboutVM aboutVM = new();
            aboutVM.Sections = _appDbContext.AboutSections.ToList();
            aboutVM.GeneralInformation = bio.GeneralInformation;
            aboutVM.Photo = bio.AboutImgUrl;
            return View(aboutVM);
        }
    }
}
