﻿using BackendFinal.DAL;
using BackendFinal.Helper;
using BackendFinal.Models;
using BackendFinal.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.IO;

namespace BackendFinal.Areas.AdminArea.Controllers
{
    [Area("adminarea")]
    [Authorize(Roles = "Admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SliderController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View(_appDbContext.Sliders.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(SliderVM sliderVM)
        {

            if (!sliderVM.Photo.CheckFileType())
            {
                ModelState.AddModelError("Photo", "Sellect a image");
                return View();

            }

            Slider slider = new()
            {
                ImgUrl = sliderVM.Photo.SaveImage(_webHostEnvironment, "images"),
                Title = sliderVM.Title,
                Discount = sliderVM.Discount,
                Description = sliderVM.Description,
            };
            _appDbContext.Sliders.Add(slider);
            _appDbContext.SaveChanges();


            return RedirectToAction("Index");



        }
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var slider = _appDbContext.Sliders.FirstOrDefault(x => x.Id == id);
            if (slider == null) return NotFound();

            string path = Path.Combine(_webHostEnvironment.WebRootPath, "img", slider.ImgUrl);
            DeleteHelper.DeleteFile(path);
            _appDbContext.Sliders.Remove(slider);
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Detail(int? id)
        {
            return View(_appDbContext.Sliders.FirstOrDefault(p => p.Id == id));
        }
        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            var slider = _appDbContext.Sliders.FirstOrDefault(x => x.Id == id);
            if (slider == null) return NotFound();
            SliderVM sliderVM = new SliderVM()
            {
                ImageUrl = slider.ImgUrl,
                Discount = slider.Discount,
                Title = slider.Title,
                Description = slider.Description
            };
            ViewBag.SliderImgUrl = slider.ImgUrl;
            return View(sliderVM);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(int? id, SliderVM sliderVM)
        {
            var slider = _appDbContext.Sliders.FirstOrDefault(c => c.Id == id);
            if (sliderVM.Photo != null)
            {
                var exist = _appDbContext.Sliders.Any(s => s.ImgUrl.ToLower() == sliderVM.Photo.FileName.ToLower() && s.Id != id);

                if (!exist)
                {
                    string path = Path.Combine(_webHostEnvironment.WebRootPath, "img", slider.ImgUrl);
                    DeleteHelper.DeleteFile(path);
                    slider.ImgUrl = sliderVM.Photo.FileName;
                }
            }

            slider.Discount = sliderVM.Discount;
            slider.Title = sliderVM.Title;
            slider.Description = sliderVM.Description;

            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
