using System.Reflection;
using Microsoft.AspNetCore.Identity;
using MSt_Calculator_API.Domain.Constants;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        //Registering services to builder
        RegisterServices(services);

        services.AddAuthentication()
            .AddBearerToken(IdentityConstants.BearerScheme);

        services.AddAuthorizationBuilder();

        services.AddSingleton(TimeProvider.System);

        services.AddAuthorization(options =>
            options.AddPolicy(Policies.CanPurge, policy => policy.RequireRole(Roles.Administrator)));

        return services;
    }

    /// <summary>
    /// This method is being used to register services to builder.
    /// </summary>
    /// <param name="services"></param>
    private static void RegisterServices(this IServiceCollection services)
    {
        var servicesAssembly = Assembly.Load("MSt_Calculator_API.Infrastructure");

        var interfacesAssembly = Assembly.Load("MSt_Calculator_API.Application");

        var serviceTypes = servicesAssembly.GetTypes();

        var interfaceTypes = interfacesAssembly.GetTypes();

        var registeredInterfaces = interfaceTypes.Where(t => t.IsInterface && t.Name.EndsWith("Service"));

        var registeredServices = serviceTypes.Where(t => t.IsClass && t.Name.EndsWith("Service"));

        foreach (var interfaceType in registeredInterfaces)
        {
            var implementationType = registeredServices.FirstOrDefault(t => interfaceType.IsAssignableFrom(t));

            if (implementationType != null)
            {
                services.AddScoped(interfaceType, implementationType);
            }
        }
    }
}
