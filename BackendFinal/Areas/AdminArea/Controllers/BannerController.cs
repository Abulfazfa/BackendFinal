using BackendFinal.DAL;
using BackendFinal.Helper;
using BackendFinal.Models;
using BackendFinal.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BackendFinal.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "Admin")]
    public class BannerController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BannerController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View(_appDbContext.Banners.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(BannerVM bannerVM)
        {

            if (!bannerVM.Photo.CheckFileType())
            {
                ModelState.AddModelError("Photo", "Sellect a image");
                return View();

            }

            Banner banner = new()
            {
                ImgUrl = bannerVM.Photo.SaveImage(_webHostEnvironment, "images"),
            };
            _appDbContext.Banners.Add(banner);
            _appDbContext.SaveChanges();


            return RedirectToAction("Index");



        }
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var banner = _appDbContext.Banners.FirstOrDefault(x => x.Id == id);
            if (banner == null) return NotFound();

            string path = Path.Combine(_webHostEnvironment.WebRootPath, "img", banner.ImgUrl);
            DeleteHelper.DeleteFile(path);
            _appDbContext.Banners.Remove(banner);
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            var banner = _appDbContext.Banners.FirstOrDefault(x => x.Id == id);
            if (banner == null) return NotFound();
            BannerVM bannerVM = new BannerVM();
            bannerVM.ImgUrl = banner.ImgUrl;
            return View(bannerVM);
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(int? id, BannerVM bannerVM)
        {
            var banner = _appDbContext.Banners.FirstOrDefault(c => c.Id == id);
            if (bannerVM.Photo != null)
            {
                var exist = _appDbContext.Banners.Any(c => c.ImgUrl.ToLower() == bannerVM.Photo.FileName.ToLower() && c.Id != id);
                if (!exist)
                {
                    string path = Path.Combine(_webHostEnvironment.WebRootPath, "img", banner.ImgUrl);
                    DeleteHelper.DeleteFile(path);
                    banner.ImgUrl = bannerVM.Photo.FileName;
                }
            }

            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
