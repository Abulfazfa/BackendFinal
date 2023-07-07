using BackendFinal.DAL;
using BackendFinal.Helper;
using BackendFinal.Models;
using BackendFinal.Services;
using BackendFinal.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace BackendFinal.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly PaginationService _paginationService;
        public ProductController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment, PaginationService paginationService)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
            _paginationService = paginationService;
        }
        public IActionResult Index(int page = 1, int take = 2)
        {
            var query = _appDbContext.Products.AsQueryable();
            var products = query
                .Include(p => p.Images)
                .Include(p => p.Category)
                .Skip(take * (page - 1))
                .Take(take)
                .ToList();
            var productCount = query.Count();
            if (productCount > 0)
            {
                PaginationVM<Product> paginationVM = new PaginationVM<Product>(products, page, _paginationService.PageCount(productCount, take));
                return View(paginationVM);
            }
            else
            {
                return RedirectToAction("Create");
            }
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
            foreach (var item in productVM.Photos)
            {
                if (!item.CheckFileType())
                {
                    ModelState.AddModelError("Photo", "Sellect a image");
                    return View();

                }
            }

            if (!ModelState.IsValid) return Content("IsValid");
            if (productVM == null) return View();
            Product product = new Product()
            {
                Name = productVM.Name,
                Desc = productVM.Desc,
                Price = productVM.Price,
                Brand = productVM.Brand,
                ProductCount = productVM.ProductCount,
                OldPrice = productVM.OldPrice,
                CategoryId = productVM.CategoryId,
            };
            List<ProductImage> images = new();
            foreach (var item in productVM.Photos)
            {
                ProductImage image = new();
                image.ImgUrl = item.SaveImage(_webHostEnvironment, "images");
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
            ViewBag.Id = id;
            if (id == null) return View();
            var exist = _appDbContext.Products.Include(p => p.Images).Include(p => p.Category).FirstOrDefault(p => p.Id == id);
            if (exist == null) return View();
            foreach (var item in exist.Images)
            {
                string path = Path.Combine(_webHostEnvironment.WebRootPath, "img", item.ImgUrl);
                DeleteHelper.DeleteFile(path);
            }
           
            _appDbContext.Products.Remove(exist);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int? id)
        {
            ViewBag.Id = id;
            if (id == null) return NotFound();
            var product = _appDbContext.Products.Include(p => p.Images).Include(p => p.Category).FirstOrDefault(x => x.Id == id);
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
                CategoryId = product.CategoryId
            };
            ViewBag.Categories = new SelectList(_appDbContext.Categories.ToList(), "Id", "Name");
            return View(productVM);
        }
        [HttpPost]
        public IActionResult Update(int? id, ProductVM productVM)
        {
            var product = _appDbContext.Products.Include(p => p.Images).Include(p => p.Category).FirstOrDefault(c => c.Id == id);
            int k = 0;
            if (productVM.Photos != null)
            {
                var exist = _appDbContext.Products
                            .ToList() // Verileri belleğe alır
                            .Any(p => productVM.Photos
                            .Any(photo => p.Images.Any(image => image.ImgUrl.ToLower() == photo.FileName.ToLower())) && p.Id != id);

                if (!exist)
                {
                    foreach (var item in product.Images)
                    {
                        string path = Path.Combine(_webHostEnvironment.WebRootPath, "images/product", item.ImgUrl);
                        DeleteHelper.DeleteFile(path);
                        
                    }
                   
                    List<ProductImage> images = new();
                    foreach (var item in productVM.Photos)
                    {
                        ProductImage image = new();
                        image.ImgUrl = item.SaveImage(_webHostEnvironment, "images");
                        images.Add(image);
                    }
                    images.FirstOrDefault().IsMain = true;
                    product.Images = images;

                }
            }

            product.Name = productVM.Name;
            product.Desc = productVM.Desc;
            product.CategoryId = productVM.CategoryId;
            product.Price = productVM.Price;
            product.OldPrice = productVM.OldPrice;  
            product.Brand = productVM.Brand;
            product.ProductCount = productVM.ProductCount;

            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteImage(string? ImgUrl, int? Id)
        {
            if (Id == null) return View();
            var exist = _appDbContext.Products.Include(p => p.Images).Include(p => p.Category).FirstOrDefault(p => p.Id == Id);
            if (exist == null) return View();
            foreach (var item in exist.Images)
            {
                if (item.ImgUrl == ImgUrl)
                {
                    string path = Path.Combine(_webHostEnvironment.WebRootPath, "img", item.ImgUrl);
                    DeleteHelper.DeleteFile(path);
                }
                
            }
             var clickedImg = exist.Images.FirstOrDefault(i => i.ImgUrl == ImgUrl);
            exist.Images.Remove(clickedImg);

            _appDbContext.SaveChanges();
            return RedirectToAction("Update", new { Id = Id});
        }
    }
}
