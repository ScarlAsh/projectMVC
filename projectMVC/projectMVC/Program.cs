using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using projectMVC.Areas.Admin.Service;
using projectMVC.Data;
using projectMVC.Generic_Repository.Interfaces;
using projectMVC.Generic_Repository.Services;
using projectMVC.Healpers;
using projectMVC.Models;
using projectMVC.Service;
using projectMVC.UnitOfWork;
using Stripe;

namespace projectMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseLazyLoadingProxies().UseSqlServer(connectionString));

            SeedData.Seed();

            //Session
            builder.Services.AddSession();

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();


            //builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();


            builder.Services.AddIdentity<ApplicationUser, IdentityRole>
                (options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 6;

                }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();


            builder.Services.AddControllersWithViews();

            builder.Services.AddRazorPages();

            //builder.Services.AddDbContext<ApplicationDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("defaultconnection")));


            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            builder.Services.AddScoped<IShopService, ShopService>();
			builder.Services.AddScoped<UserManager<ApplicationUser>>();
			builder.Services.AddScoped<SignInManager<ApplicationUser>>();
            builder.Services.AddScoped<IProductServices, ProductServices>();
			//builder.Services.AddScoped(sp => sp.GetService<ShopService>());

			/*.SetApiKey(ConfigurationBinder.GetSection("Stripe")["SecretKey"]);*/
			Stripe.StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe")["Secretkey"];
			//Adding the StripeSetting class 
			builder.Services.Configure<StripeSetting>(builder.Configuration.GetSection("Stripe"));


			var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "Admin",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=DefaultPage}/{id?}");

            

            app.MapRazorPages();

            app.Run();
        }
    }
}