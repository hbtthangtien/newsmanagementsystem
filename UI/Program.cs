using Application;
using Microsoft.AspNetCore.Builder;
using Persistences;
using Persistences.DatabaseConfig;
using UI.Helper;
namespace UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext(builder.Configuration);
            builder.Services.AddPersistence();
            builder.Services.AddApplication();
            builder.Services.AddAutoMapper(typeof(ApplicationMapper));
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
                    name:"staff",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=NewsArticle}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
