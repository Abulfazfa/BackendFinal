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
    public class BlogController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BlogController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View(_appDbContext.Blogs.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(BlogVM blogVM)
        {

            if (!blogVM.Photo.CheckFileType())
            {
                ModelState.AddModelError("Photo", "Sellect a image");
                return View();
            }

            Blog blog = new()
            {
                ImgUrl = blogVM.Photo.SaveImage(_webHostEnvironment, "images"),
                Title = blogVM.Title,
                Desc = blogVM.Desc,
                CreatedDate = blogVM.CreatedDate,
                Date = blogVM.Date
            };
            _appDbContext.Blogs.Add(blog);

            return RedirectToAction("Index");


        }
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var blog = _appDbContext.Blogs.FirstOrDefault(x => x.Id == id);
            if (blog == null) return NotFound();

            string path = Path.Combine(_webHostEnvironment.WebRootPath, "img", blog.ImgUrl);
            DeleteHelper.DeleteFile(path);
            _appDbContext.Blogs.Remove(blog);
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Detail(int? id)
        {
            return View(_appDbContext.Blogs.FirstOrDefault(p => p.Id == id));
        }
        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            var blog = _appDbContext.Blogs.FirstOrDefault(x => x.Id == id);
            if (blog == null) return NotFound();
            BlogVM blogVM = new BlogVM();
            blogVM.ImgUrl = blog.ImgUrl;
            blogVM.Date = blog.Date;
            blogVM.Title = blog.Title;
            blogVM.CreatedDate = blog.CreatedDate;
            blogVM.Desc = blog.Desc;
            return View(blogVM);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(int? id, BlogVM blogVM)
        {
            var blog = _appDbContext.Blogs.FirstOrDefault(c => c.Id == id);
            if (blogVM.Photo != null)
            {
                var exist = _appDbContext.Blogs.Any(c => c.ImgUrl.ToLower() == blogVM.Photo.FileName.ToLower() && c.Id != id);
                if (!exist)
                {
                    string path = Path.Combine(_webHostEnvironment.WebRootPath, "img", blog.ImgUrl);
                    DeleteHelper.DeleteFile(path);
                    blog.ImgUrl = blogVM.Photo.FileName;
                }
            }
            blog.Desc = blogVM.Desc;
            blog.CreatedDate = blogVM.CreatedDate;
            blog.Desc = blogVM.Desc;
            blog.Date = blogVM.Date;

            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
