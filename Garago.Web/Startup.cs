using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Garago.Data;
using Garago.Data.Repos;
using Garago.Data.Repos.GarageSales.Impl;
using Garago.Data.Repos.Products.Impl;
using Garago.Data.Repos.Users.Impl;
using Garago.Domain;
using Garago.Services.Service.GarageSales;
using Garago.Services.Service.GarageSales.Impl;
using Garago.Services.Service.Products;
using Garago.Services.Service.Products.Impl;
using Garago.Services.Service.Users;
using Garago.Services.Service.Users.Impl;
using Garago.Services.ViewModels.Utils.Facebook;
using Garago.Services.ViewModels.Utils.Facebook.Impl;
using Garago.Web.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Garago.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                new RoleSecurityManager().loadAuthorization(options);
            });

            string connectionString = Configuration["ConnectionStrings:garago"];

            services.AddDbContext<GaragoContext>(o => o.UseMySql(connectionString));

            //Add entity user to your services, and add a entity framework store using the garago context, add a token provider
            services.AddIdentity<GaragoUser, IdentityRole>().AddEntityFrameworkStores<GaragoContext>().AddDefaultTokenProviders();
            /*
            services.AddHttpClient<FacebookClient>();

            services.AddHttpClient<AccountService>();
            */
            services.AddScoped<IProductsRepo, ProductsRepo>();

            services.AddScoped<IGarageSaleRepo, GarageSaleRepo>();

            services.AddScoped<IUsersRepo, UsersRepo>();

            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IGarageSaleService, GarageSaleService>();

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<IFacebookClient, FacebookClient>();

            services.AddDistributedMemoryCache();

            services.AddSession(o =>
            {
                //SEt timeout in session.
                o.IdleTimeout = TimeSpan.FromSeconds(10);

                o.Cookie.HttpOnly = true;

                o.Cookie.IsEssential = true;
            });

            services.AddCors();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, GaragoContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseSession();

            app.UseCors(builder => builder.AllowAnyHeader()
                                        .AllowAnyMethod()
                                        .AllowAnyOrigin()
                                        .AllowCredentials());
            app.UseMvc();
        }
    }
}
