using BackendFinal.DAL;
using BackendFinal.Models;
using BackendFinal.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;

namespace BackendFinal.ViewComponents
{
    public class BlogViewComponent : ViewComponent
    {
        private readonly AppDbContext _appDbContext;

        public BlogViewComponent(AppDbContext appDbContex)
        {
            _appDbContext = appDbContex;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            HomeVM homeVM = new HomeVM();
            homeVM.Blogs = _appDbContext.Blogs.ToList();
            homeVM.Says = _appDbContext.Says.ToList();
            return View(homeVM);
        }
    }
}
