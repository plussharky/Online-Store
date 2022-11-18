using Store.Models;
using Strore.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Store
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
            //"Server=(localdb)\\MSSQLLocalDB;Database=Store;Trusted_Connection=True;MultipleActiveResultSets=true"));
            //"Server=(localdb)\\MSSQLLocalDB; Database=Store; Trusted_Connection=True; MultipleActiveResultSets=True;"));
            "Server=localhost;Database=master;Trusted_Connection=True;"));
            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddRazorPages();
            services.AddMemoryCache();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IOrderRepository, EFOrderRepository>();
            services.AddSession();
            services.AddHttpContextAccessor();
            services.AddControllersWithViews();  
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            var scope = ((IApplicationBuilder)app).ApplicationServices.CreateScope();
            var service = scope.ServiceProvider.GetService<IProductRepository>();
            SeedData.EnsurePopulated(app);
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();
            app.UseSession();
            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Product}/{action=List}/{id?}"
            //    );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: null,
                    pattern: "{category}/Page{productPage:int}",
                    defaults: new { controller = "Product", action = "List" }
                    );

                endpoints.MapControllerRoute(
                    name: null,
                    pattern: "Page{productPage:int}",
                    defaults: new { controller = "Product", action = "List", productPage = 1 }
                    );

                endpoints.MapControllerRoute(
                    name: null,
                    pattern: "{category}",
                    defaults: new { controller = "Product", action = "List", productPage = 1 }
                    );

                endpoints.MapControllerRoute(
                    name: null,
                    pattern: "",
                    defaults: new { controller = "Product", action = "List", productPage = 1 }
                    );

                endpoints.MapControllerRoute(
                     name: null,
                    pattern: "{controller=Product}/{action=List}/{id?}"
                    );
            });

            app.Run();
        }
    }
}
