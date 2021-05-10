using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.Interfaces;
using DAL.Models;
using Warehouse.Data;
using BLL.Repositories;

namespace Warehouse
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
            services.AddDbContext<OracleDBContext>(optionsAction:builder => 
                builder.UseOracle("DATA SOURCE=localhost:1521;PASSWORD=qaz123QAZ!@#;USER ID=ABOBA", options => options
                .UseOracleSQLCompatibility("11")));

            services.AddScoped<IOperatorRepository, OperatorRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IGoodsCategoryRepo, GoodsCategoryRepo>();
            services.AddScoped<IGoodsRepository, GoodsRepository>();
            services.AddScoped<IDimensionRepo, DimensionRepo>();
            services.AddScoped<IProviderRepo, ProviderRepo>();
            services.AddScoped<ILeftoverRepo, LeftoverRepo>();
            services.AddScoped<ISuppliersWithGoodsRepository, SuppliersWithGoodsRepository>();
            services.AddScoped<IFileWithGoodsRepo, FileWithGoodsRepo>();
            services.AddScoped<IDecommLogRepo, DecommLogRepo>();

            services
        .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.AccessDeniedPath = "/Auth/NotAllowedPage";
            options.LoginPath = "/Auth/LoginPage";
        });

            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
