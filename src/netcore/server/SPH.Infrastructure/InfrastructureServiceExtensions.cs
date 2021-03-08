using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SPH.Entity.Contexts;
using SPH.Infrastructure.Abstractions;
using SPH.Infrastructure.Filters;
using SPH.Infrastructure.UnitOfWork.Core;
using SPH.Infrastructure.UoW;
using SPH.Shared.Configurations;
using SPH.Shared.Extensions;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class InfrastructureServiceExtensions
    {
        public static void AddUnitOfWorkPool(this IServiceCollection services, Action<UnitOfWorkPoolOptionsBuilder> optionsAction)
        {
            var optionsBuilder = new UnitOfWorkPoolOptionsBuilder();
            optionsAction.Invoke(optionsBuilder);

            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddSingleton(typeof(UnitOfWorkPoolOptions), optionsBuilder.Options);
            services.AddScoped<IUnitOfWorkPool, UnitOfWorkPool>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddMvcCore(options =>
            {
                options.Filters.Add(typeof(UnitOfWorkPoolTransactionFilter));
            });
        }

        public static void AddUnitOfWork(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SPHContext>(options =>
                options.UseMySql(configuration.GetOptions<DatabaseSetting>(nameof(DatabaseSetting)).DefaultDatabase)
            );
            services.AddUnitOfWorkPool(optionBuilder =>
            {
                optionBuilder.AddUnitOfWork<SPHContext>(nameof(SPHContext));
            });

            // Register included UoW: SPH
            services.AddScoped<ISPHUoW, SPHUoW>();
        }
    }
}
