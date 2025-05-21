using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.DNSimple.OpenApiClientUtil.Registrars;

namespace Soenneker.DNSimple.Delegation.Registrars;

/// <summary>
/// A .NET typesafe implementation of DNSimple's Delegation API
/// </summary>
public static class DNSimpleDelegationUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IDNSimpleDelegationUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddDNSimpleDelegationUtilAsSingleton(this IServiceCollection services)
    {
        services.AddDNSimpleOpenApiClientUtilAsSingleton().TryAddSingleton<IDNSimpleDelegationUtil, DNSimpleDelegationUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IDNSimpleDelegationUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddDNSimpleDelegationUtilAsScoped(this IServiceCollection services)
    {
        services.AddDNSimpleOpenApiClientUtilAsSingleton().TryAddScoped<IDNSimpleDelegationUtil, DNSimpleDelegationUtil>();

        return services;
    }
}