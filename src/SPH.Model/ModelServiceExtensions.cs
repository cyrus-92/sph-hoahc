using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SPH.Model
{
    public static class ModelServiceExtensions
    {
        public static void AddFluentValidator(this IServiceCollection services)
        {
            services.AddMvcCore().AddFluentValidation(opts =>
            {
                opts.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                opts.ImplicitlyValidateChildProperties = true;
                opts.ValidatorOptions.CascadeMode = FluentValidation.CascadeMode.Stop;
            });
        }
    }
}
