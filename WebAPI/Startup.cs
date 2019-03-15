using BLL;
using BLL.Interfaces;
using DAL.Context;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc; 
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Threading.Tasks;
using WebAPI.Configurations;

namespace WebAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Mapper Configuration
            MapperConfig.Configure();

            //Services
            services.AddDbContext<DALContext>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "WebAPI", Version = "v1" });
            });

            //Caching
            services.AddResponseCaching();
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
                app.UseHsts();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI");
            });

            app.UseResponseCaching();

            app.Use(async (context, next) =>
            {
                context.Response.GetTypedHeaders().CacheControl =
                    new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromSeconds(10)
                    };
                context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
                    new string[] { "Accept-Encoding" };

                await next();
            });    
 
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
