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
                ImgUrl = bio.LogoUrl,
                Address = bio.Address,
                Email = bio.Email,
                PhoneNumber = bio.PhoneNumber,
                WorkingTime = bio.WorkingTime,
                GeneralInformation = bio.GeneralInformation,
                AboutImgUrl = bio.AboutImgUrl
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
                if (bioVM.Photo != null)
                {
                    string path = Path.Combine(_webHostEnvironment.WebRootPath, "img", existbio.LogoUrl);
                    DeleteHelper.DeleteFile(path);
                    existbio.LogoUrl = bioVM.Photo.FileName;
                }
                if (bioVM.AboutPhoto != null)
                {
                    string path = Path.Combine(_webHostEnvironment.WebRootPath, "img", existbio.AboutImgUrl);
                    DeleteHelper.DeleteFile(path);
                    existbio.AboutImgUrl = bioVM.AboutPhoto.FileName;
                }
                
            }
            existbio.Email = bioVM.Email;
            existbio.Address = bioVM.Address;
            existbio.PhoneNumber = bioVM.PhoneNumber;
            existbio.WorkingTime = bioVM.WorkingTime;
            existbio.GeneralInformation = bioVM.GeneralInformation;

            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
