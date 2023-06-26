using BackendFinal.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BackendFinal.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Banner> Banners { get; set; }
    }
}
