using BackendFinal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace BackendFinal.Hubs
{
    public class CommerceHub : Hub
    {
        private readonly UserManager<AppUser> _userManager;

        public CommerceHub(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task SendMessage(string user, Product product)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, product);
        }
    }
}
