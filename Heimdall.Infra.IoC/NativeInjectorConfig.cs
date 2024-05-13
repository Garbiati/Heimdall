using Heimdall.Application.Interfaces;
using Heimdall.Application.Mappings;
//using Heimdall.Application.Services;
using Heimdall.Domain.Interfaces;
using Heimdall.Infra.Data.Context;
using Heimdall.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Heimdall.Infra.IoC
{
    public static class NativeInjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            // services.AddScoped<IExampleService, ExampleService>();
            //services.AddScoped<IExampleRepository, ExampleRepository>();

            services.AddAutoMapper(typeof(ExampleMappingProfile));

        }
    }
}