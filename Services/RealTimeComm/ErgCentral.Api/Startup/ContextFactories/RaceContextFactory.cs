using ErgCentral.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

namespace ErgCentral.Api.Startup.ContextFactories
{
    public class RaceContextFactory : IDesignTimeDbContextFactory<TelemetryContext>
    {
        public TelemetryContext CreateDbContext(string[] args)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true)
                .AddJsonFile($"appsettings.{environment}.json", true);

            var configuration = builder.Build();

            var connectionString = configuration.GetConnectionString(nameof(TelemetryContext));
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ConfigurationNotInitializedException($"Connection string cannot be null or empty. Verify the connection string in the appsettings.json for the current environment ({environment}) is correct.");
            }
            var optionsBuilder = new DbContextOptionsBuilder<TelemetryContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new TelemetryContext(optionsBuilder.Options);
        }
    }
}