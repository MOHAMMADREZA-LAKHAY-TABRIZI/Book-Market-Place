using ApplicationServices.Mapper;
using ApplicationServices.Services;
using ApplicationServices.Services.BookCategoryServices;
using ApplicationServices.Services.BookStoreServices;
using BookMarketPlaceWebAPI.Validators;
using EF.Persistance.DataBase;
using EF.Persistance.Repository;
using Entities.IRepositories;
using Entities.IUnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BookMarketPlaceWebAPI
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


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            // services.AddScoped<BookValidator>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "My API V1");

            });
        }
    }
}
