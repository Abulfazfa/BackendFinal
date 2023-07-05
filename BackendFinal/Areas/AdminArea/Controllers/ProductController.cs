using BackendFinal.DAL;
using BackendFinal.Models;
using BackendFinal.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Drawing;

namespace BackendFinal.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public ProductController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            return View(_appDbContext.Products.Include(p => p.Images).ToList());
        }
        public IActionResult Detail(int? id)
        {
            return View(_appDbContext.Products.Include(p => p.Images).FirstOrDefault(p => p.Id == id));
        }

        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_appDbContext.Categories.ToList(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductVM productVM)
        {
            

            ViewBag.Categories = new SelectList(_appDbContext.Categories.ToList(), "Id", "Name");
            ModelState.MaxAllowedErrors = 5;
            if (!ModelState.IsValid) return Content("IsValid");
            if (productVM == null) return View();
            Product product = new Product()
            {
                Name = productVM.Name,
                Desc = productVM.Desc,
                Price = productVM.Price,
                Brand = productVM.Brand,
                ProductCount = productVM.ProductCount,
                OldPrice = productVM.OldPrice
            };
            ProductImage image = new();
            List<ProductImage> images = new();
            foreach (var item in productVM.Photos)
            {
                image.ImgUrl = item.FileName;
                images.Add(image);
            }
            images.FirstOrDefault().IsMain = true;
            product.Images = images;

            _appDbContext.Products.Add(product);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null) return View();
            var exist = _appDbContext.Products.FirstOrDefault(p => p.Id == id);
            if (exist != null) return View();
            _appDbContext.Products.Remove(exist);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            var product = _appDbContext.Products.FirstOrDefault(x => x.Id == id);
            if (product == null) return NotFound();
            ProductVM productVM = new()
            {
                Name = product.Name,
                Desc = product.Desc,
                Price = product.Price,
                OldPrice = product.OldPrice,
                Brand = product.Brand,
                ProductCount = product.ProductCount,
                Images = product.Images,
                Category = product.Category,
            };
            ViewBag.Categories = new SelectList(_appDbContext.Categories.ToList(), "Id", "Name");
            return View(productVM);
        }
        [HttpPost]
        public IActionResult Update(object obj)
        {
            return View();
        }
    }
}
