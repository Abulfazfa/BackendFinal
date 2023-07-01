using BackendFinal.DAL;
using BackendFinal.Models;
using BackendFinal.Services;
using Microsoft.AspNetCore.Identity;

namespace BackendFinal
{
    public static class ServiceRegistration
    {
        public static void ServiceRegister(this IServiceCollection services)
        {
            services.AddControllersWithViews();
            
            services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromMinutes(10);
            });
            services.AddHttpContextAccessor();
            services.AddIdentity<AppUser, IdentityRole>(option =>
            {
                option.Password.RequiredLength = 8;
                option.Password.RequireNonAlphanumeric = true;
                option.Password.RequireUppercase = true;
                option.Password.RequireLowercase = true;
                option.Password.RequireDigit = true;

                option.User.RequireUniqueEmail = true;
                option.Lockout.AllowedForNewUsers = true;
                option.Lockout.MaxFailedAccessAttempts = 3;
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);

            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
            services.AddSignalR();
            services.AddScoped<FileService>();
            services.AddScoped<EmailService>();
        }
    }
}
