using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Core.Behaviors;
using System.Reflection;

namespace SchoolManagement.Core
{
    public static class DependencyInjectionCore
    {
        public static IServiceCollection AddServiceCoreToContainer(this IServiceCollection services)
        {

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(typeof(AssemblyInformation).Assembly);

            services.AddValidatorsFromAssembly((typeof(AssemblyInformation).Assembly));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(BehaviorValidators<,>));

            return services;
        }



    }
}
