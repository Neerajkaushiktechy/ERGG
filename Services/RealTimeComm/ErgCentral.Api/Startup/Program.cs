using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer.Sinks.MSSqlServer.Options;
using System;

namespace ErgCentral.Api.Startup
{
    public static class Program
    {
        #region Public Methods

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }

        public static int Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.MSSqlServer(
                    connectionString: "Data Source=tcp:erg.database.windows.net,1433;Database=Telemetry;User ID=ivan;Password=RaceGame@1;Encrypt=true;app=Poc.CosmosDb;MultipleActiveResultSets=True",
                    sinkOptions: new SinkOptions { TableName = "LogEvents" })
                .CreateLogger();

            try
            {
                Log.Information("Starting Telemetry");
                CreateHostBuilder(args).Build().Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Telemetry terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        #endregion Public Methods
    }
}