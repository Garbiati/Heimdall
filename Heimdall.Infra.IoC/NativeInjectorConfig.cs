using Heimdall.Application.Interfaces;
using Heimdall.Application.Mappings;
using Heimdall.Application.Services;

//using Heimdall.Application.Services;
using Heimdall.Domain.Interfaces;
using Heimdall.Infra.Data.Context;
using Heimdall.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reminder.Infra.Data.Repositories;


namespace Heimdall.Infra.IoC
{
    public static class NativeInjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IServiceBase<,,,>), typeof(ServiceBase<,,,>));
        }
    }
}