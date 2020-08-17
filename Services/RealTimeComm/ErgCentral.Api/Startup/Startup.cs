using AutoMapper;
using ErgCentral.Api.Hubs;
using ErgCentral.Api.Startup.Extensions;
using ErgCentral.Business;
using ErgCentral.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace ErgCentral.Api.Startup
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen();

            services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            services.AddSignalR();

            services.AddAutoMapper(typeof(Startup), typeof(BusinessModule));

            services.AddCustomServices();

            services.AddDbContext<TelemetryContext>(x => x.UseSqlServer(Configuration.GetConnectionString(nameof(TelemetryContext))));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSerilogRequestLogging();

            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Erg Central Telemetry API V1"); });

            app.UseCors("CorsPolicy");

            app.UseSignalR(options =>
            {
                options.MapHub<ChatHub>("/hub");
            });

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}