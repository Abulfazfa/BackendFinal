using BackendFinal.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendFinal.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public ProductController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            return View(_appDbContext.Products.Include(p => p.Images));
        }
        public IActionResult Search(string search)
        {
            var products = _appDbContext.Products
                .Where(p => p.Name.ToLower().Contains(search.ToLower()))
                .Take(3)
                .OrderByDescending(p => p.Id)
                .ToList();
            return PartialView("_SearchPartial", products);
        }
    }
}
