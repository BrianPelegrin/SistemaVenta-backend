using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SistemaVenta.Application.Behaviors;

namespace SistemaVenta.Application
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(x => x.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            services.AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
