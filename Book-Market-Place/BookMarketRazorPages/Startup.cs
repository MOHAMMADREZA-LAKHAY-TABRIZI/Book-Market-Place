using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationServices.Mapper;
using ApplicationServices.Services;
using ApplicationServices.Services.BookCategoryServices;
using ApplicationServices.Services.BookStoreServices;
using EF.Persistance.DataBase;
using EF.Persistance.Repository;
using Entities.IRepositories;
using Entities.IUnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookMarketRazorPages
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
            services.AddScoped(typeof(IRepositories<>), typeof(Repositories<>));//??

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IBookServices, BookServices>();

            services.AddScoped<IBookCategoryService, BookCategoryService>();

            services.AddScoped<IBookStoreService, BookStoreService>();

            services.AddAutoMapper(typeof(BookStoreMapper));

            services.AddAutoMapper(typeof(BookCategoryMapper));

            services.AddAutoMapper(typeof(BooKMapper));

            services.AddDbContext<BookMarketPlaceDBContex>(database => database.UseSqlServer(Configuration.GetConnectionString("BookMarketPlace")));

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
