using BackendFinal.DAL;
using BackendFinal.Helper;
using BackendFinal.Models;
using BackendFinal.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace BackendFinal.Areas.AdminArea.Controllers
{
    public class BioController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BioController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var bio = _appDbContext.Bios.FirstOrDefault();
            BioVM bioVM = new BioVM()
            {
                //Photo
                Address = bio.Address,
                Email = bio.Email,
                PhoneNumber = bio.PhoneNumber,
                WorkingTime = bio.WorkingTime
            };
            return View(bioVM);
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Index(BioVM bioVM)
        {
            var existbio = _appDbContext.Bios.FirstOrDefault();
            if (existbio != null)
            {
                string path = Path.Combine(_webHostEnvironment.WebRootPath, "img", existbio.LogoUrl);
                DeleteHelper.DeleteFile(path);
                existbio.LogoUrl = bioVM.Photo.FileName;
                existbio.Email = bioVM.Email;
                existbio.Address = bioVM.Address;
                existbio.PhoneNumber = bioVM.PhoneNumber;
                existbio.WorkingTime = bioVM.WorkingTime;
            }

            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
