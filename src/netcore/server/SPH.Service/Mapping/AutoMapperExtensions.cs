using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SPH.Service.Mapping.Profiles;
using System;

namespace SPH.Service.Mapping
{
    public static class AutoMapperExtensions
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                IServiceProvider provider = services.BuildServiceProvider();

                mc.AllowNullCollections = true;
                mc.AddProfile(new UserProfile(provider.GetService<IConfiguration>()));
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
