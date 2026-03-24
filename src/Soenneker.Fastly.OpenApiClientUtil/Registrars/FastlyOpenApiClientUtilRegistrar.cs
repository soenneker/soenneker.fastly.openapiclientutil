using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Fastly.HttpClients.Registrars;
using Soenneker.Fastly.OpenApiClientUtil.Abstract;

namespace Soenneker.Fastly.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class FastlyOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="FastlyOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddFastlyOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddFastlyOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IFastlyOpenApiClientUtil, FastlyOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="FastlyOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddFastlyOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddFastlyOpenApiHttpClientAsSingleton()
                .TryAddScoped<IFastlyOpenApiClientUtil, FastlyOpenApiClientUtil>();

        return services;
    }
}
