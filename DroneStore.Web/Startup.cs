using System;
using DroneStore.Data;
using DroneStore.Services.Catalog;
using DroneStore.Services.Media;
using DroneStore.Services.Services.Discounts;
using DroneStore.Services.Services.Orders;
using DroneStore.Web.Identity;
using DroneStore.Web.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DroneStore.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(7);
                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                options.Cookie.Name = "DroneStore.Session";
                options.Cookie.IsEssential = true;
            });

            services.AddDbContext<AppIdentityDbContext>(
                option => option.UseSqlServer(Configuration["ConnectionStrings:IdentityConnection"]));

            services.AddIdentity<AppUser, IdentityRole>(SetUpIdentityOptions)
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddDbContext<StoreDbContext>(
                options => options.UseSqlServer(Configuration["ConnectionStrings:CatalogConnection"]));

            services.AddTransient<DbContext, StoreDbContext>();
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            services.AddHttpContextAccessor();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddScoped<ICatalogService, CatalogService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IDiscountService, DiscountService>();

            services.AddScoped<ICatalogViewModelService, CatalogViewModelService>();
            services.AddScoped<IShoppingCartViewModelService, ShoppingCartViewModelService>();
            services.AddScoped<IOrderViewModelService, OrderViewModelService>();
            services.AddScoped<IWishListViewModelService, WishListViewModelService>();
            services.AddScoped<IDiscountViewModelService, DiscountViewModelService>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                //.AddFacebook("FaceBook", options =>
                //{
                //	options.AppId = "";
                //	options.AppSecret = "";
                //})
                .AddCookie()
                .AddGoogle("GoogleCookie", options =>
                {
                    options.ClientId = "183412365232-f7lc2nvgggp8eeur24escgng6fac7bnc.apps.googleusercontent.com";
                    options.ClientSecret = "89wBh8XO-d3LpuMpQLzVpdpI";
                });

            services.ConfigureApplicationCookie(configureOptions =>
            {
                configureOptions.LoginPath = "/Auth/Login";
                configureOptions.AccessDeniedPath = "/Auth/AccessDenied";
                configureOptions.LogoutPath = "/Auth/Logout";
                configureOptions.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseSession();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "catalog",
                    template: "{controller=Catalog}/{action=Catalog}/{currentPage?}/{itemsPerPage?}/{currentBrand?}/{sortBy?}");

                routes.MapRoute(
                    name: "shoppingcart",
                    template: "{controller=ShoppingCart}/{action=Index}/{itemId?}/{quantity?}/{backUrl?}");
            });

            IdentitySettings.SeedAccounts(app.ApplicationServices, Configuration).Wait();
            var storeDbContext = app.ApplicationServices.GetRequiredService<StoreDbContext>();
            SeedData.Seed(storeDbContext);
        }

        private static void SetUpIdentityOptions(IdentityOptions options)
        {
            options.User.RequireUniqueEmail = true;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 2;
            options.Password.RequireDigit = true;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = true;
            options.Lockout.MaxFailedAccessAttempts = 3;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
        }
    }
}
