using ErgCentral.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ErgCentral.Repository.Interfaces;
using ErgCentral.Repository.Repository;
using ErgCentral.Services.Interfaces;
using ErgCentral.Repository.Entity;

namespace ErgCentral.Services.Services
{
    public static class Bootstraper
    {
        public static void InitializeRepository(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ErgCentralContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ErgCentralConnection")));
                 services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IRaceRepository, RaceRepository>();
            services.AddScoped<IParticipantRepository, ParticipantRepository>();
            services.AddScoped<IBaseRepository<ApplicationUser>, BaseRepository<ApplicationUser>>();
            services.AddScoped<IBaseRepository<Races>, BaseRepository<Races>>();
            services.AddScoped<IBaseRepository<Participants>, BaseRepository<Participants>>();

        }
        public static void InitializeServices(IServiceCollection services, IConfiguration configuration)
        {
            InitializeRepository(services, configuration);
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IRaceService, RaceService>();
            services.AddScoped<IParticipantService, ParticipantService>();
        }

        }
}
