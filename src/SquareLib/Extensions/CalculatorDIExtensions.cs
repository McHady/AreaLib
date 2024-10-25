using AreaLib.Calculator;
using AreaLib.Configuration;
using AreaLib.Factory;
using AreaLib.Factory.Impl;
using Microsoft.Extensions.DependencyInjection;

namespace AreaLib.Extensions;

public static class CalculatorDiExtensions
{
    public static IServiceCollection AddAreaCalculators(this IServiceCollection services,
        Action<ConfigurationBuilder>? builder = null)
        => services.AddTransient<ICalculatorFactory, DICalculatorFactory>()
            .AddCalculators()
            .AddConfiguredCalculators(builder);

    private static IServiceCollection AddConfiguredCalculators(this IServiceCollection services, Action<ConfigurationBuilder>? builder = null)
    {
        if (builder == null)
            return services;

        ConfigurationBuilder config = new();
        builder.Invoke(config);

        if (!config.AddedTypesWithCalculators.Any() && !config.AddedTypesWithImplementations.Any())
            return services;

        foreach (var type in config.AddedTypesWithCalculators)
        {
            services.AddTransient(GetServiceType(type.Type), type.Calculator);
        }

        foreach (var type in config.AddedTypesWithImplementations)
        {
            services.AddTransient(GetServiceType(type.Type), (_) => type.Calculator);
        }

        return services;
    }

    private static Type GetServiceType(Type type)
    {
        var calculatorInterface = typeof(IAreaCalculator<>);   
        return calculatorInterface.MakeGenericType(type);
    }
}
