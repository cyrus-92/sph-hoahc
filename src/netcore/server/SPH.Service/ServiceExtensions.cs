using Microsoft.Extensions.Configuration;
using SPH.Model;
using SPH.Service.DataGov;
using SPH.Service.Mapping;
using SPH.Service.Users;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
            services.AddUnitOfWork(configuration);
            services.AddFluentValidator();
            services.AddAutoMapper();

            // Register services here
            services.AddScoped<IUserService, UserService>();
            services.AddTransient<ITransportService, TransportService>();
        }
    }
}
