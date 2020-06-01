using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Services;
using DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace API
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
            services.AddControllers().AddNewtonsoftJson();
            services.AddDbContext<DBContext>(builder =>
                builder.UseSqlite(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("API")));
            services.AddScoped<ISpecificationService, SpecificationsService>();

            services.AddScoped<IBikeService, BikeService>();
            
            services.AddScoped<ICommentsServices, CommentsService>();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("api", new OpenApiInfo()
                {
                    Title = "bikesApi",
                    Version = "1.0"
                });
            });
            
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/api/swagger.json", "api");
                });
            }
            
            // app.UseHttpsRedirection();

            app.UseStaticFiles();

            var path = Path.Combine(env.ContentRootPath, "images");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            
            var provider = new FileExtensionContentTypeProvider();

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(path),
                RequestPath = new PathString("/images"),
                ContentTypeProvider = provider
            });
            
            app.UseRouting();

            app.UseCors(b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}