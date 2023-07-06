using BackendFinal.DAL;
using BackendFinal.Hubs;
using BackendFinal.Models;
using BackendFinal.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace BackendFinal.Controllers
{
    public class CommerceController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHubContext<CommerceHub> _hubContext;
        public CommerceController(UserManager<AppUser> userManager, IHubContext<CommerceHub> hubContext)
        {
            _userManager = userManager;
            _hubContext = hubContext;
        }
        public IActionResult Index(List<BasketVM> basketVM)
        {
            if (basketVM == null) return BadRequest();
            ViewBag.ProductList = basketVM;
            return View();
        }
        public async Task<IActionResult> ShowAlert(string name)
        {
            var user = _userManager.FindByNameAsync(name).Result;
            await _hubContext.Clients.Client(user.ConnectionId).SendAsync("ShowAlert", user.Fullname);
            return Content("sended");
        }
    }
}
