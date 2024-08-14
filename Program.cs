using IronDome2.Data;
using IronDome2.Data.Weapon;
using IronDome2.Models;
using IronDome2.Services;
using Microsoft.EntityFrameworkCore;

namespace IronDome2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(option => 
                option.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

            builder.Services.AddSingleton<WeaponService>();
            
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Launches}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
// 
// 