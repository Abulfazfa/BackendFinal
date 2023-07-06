using BackendFinal.DAL;
using BackendFinal.Hubs;
using BackendFinal.Models;
using BackendFinal.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BackendFinal.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public BasketController(UserManager<AppUser> userManager, IHubContext<CommerceHub> hubContext, AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddBasket(int? id)
        {

            if (id == null) return NotFound();
            var product = _appDbContext.Products.Include(p => p.Images).FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            List<BasketVM> products;
            if (Request.Cookies["basket"] == null)
            {
                products = new List<BasketVM>();
            }
            else
            {
                products = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
            }
            var existproduct = products.Find(x => x.Id == id);
            if (existproduct == null)
            {
                BasketVM basketVM = new BasketVM()
                {
                    Id = product.Id,
                    BasketCount = 1
                };
                products.Add(basketVM);
            }
            else
            {
                existproduct.BasketCount++;
            }



            Response.Cookies.Append("basket", JsonConvert.SerializeObject(products), new CookieOptions { MaxAge = TimeSpan.FromMinutes(15) });


            return RedirectToAction("Index", "Home");
        }
        public IActionResult RemoveItem(int? id)
        {
            if (id == null) return NotFound();

            var products = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
            var existproduct = products.Find(x => x.Id == id);
            products.Remove(existproduct);
            Response.Cookies.Append("basket", JsonConvert.SerializeObject(products), new CookieOptions { MaxAge = TimeSpan.FromMinutes(15) });
            return RedirectToAction("ShowBasket");
        }
        public IActionResult ShowBasket()
        {

            string basket = Request.Cookies["basket"];
            List<BasketVM> products;
            if (basket == null)
            {
                products = new List<BasketVM>(); 
            }
            else
            {
                products = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
                foreach (var item in products)
                {
                    Product existproduct = _appDbContext.Products.Include(p => p.Images).FirstOrDefault(p => p.Id == item.Id);
                    item.Name = existproduct.Name;
                    item.Price = existproduct.Price;
                    item.ImgUrl = existproduct.Images.FirstOrDefault().ImgUrl;
                }
            }


            return View(products);
        }
        
        
    }
}

 