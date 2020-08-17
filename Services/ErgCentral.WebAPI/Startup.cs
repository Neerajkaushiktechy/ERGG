using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErgCentral.Repository;
using ErgCentral.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ErgCentral.WebAPI
{
    public class Startup
    {
        public Startup(IHostEnvironment hostingEnvironment)
        {
            var builder = new ConfigurationBuilder()
                 .SetBasePath(hostingEnvironment.ContentRootPath)
                 .AddJsonFile($"appsettings.json", optional: true, reloadOnChange: true);
            this.Configuration = builder.Build();
            //Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ErgCentralContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString("ErgCentralConnection")));
            services.AddControllers();
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();
            Bootstraper.InitializeServices(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                //c.SwaggerEndpoint($"{env.ContentRootPath}swagger/v1/swagger.json", "Test.Web.Api");
                c.SwaggerEndpoint("v1/swagger.json", "MyAPI V1");
            });

            

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
