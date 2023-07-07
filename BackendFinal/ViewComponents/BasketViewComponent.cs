using BackendFinal.DAL;
using BackendFinal.Models;
using BackendFinal.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BackendFinal.ViewComponents
{
    public class BasketViewComponent : ViewComponent
    {
        private readonly AppDbContext _appDbContext;

        public BasketViewComponent(AppDbContext appDbContex)
        {
            _appDbContext = appDbContex;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var product = _appDbContext.Products.Include(p => p.Images).ToList();
            //return View(await Task.FromResult(product));
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
