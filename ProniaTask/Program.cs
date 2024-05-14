using Microsoft.EntityFrameworkCore;
using ProniaTask.Business.Services.Abstracts;
using ProniaTask.Business.Services.Concretes;
using ProniaTask.Core.RepositoryAbstracts;
using ProniaTask.Data.DAL;
using ProniaTask.Data.RepositoryConcretes;

namespace ProniaTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<ISliderService, SliderService>();


            builder.Services.AddScoped<ISliderRepository, SliderRepository>();




            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                       name: "areas",
                       pattern: "{area:exists}/{controller=dashboard}/{action=index}/{id?}"
                 );
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=home}/{action=index}/{id?}"
                );

            app.Run();
        }
    }
}