using AreaLib.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SquareLib.Calculator;
using SquareLib.Factory;
using SquareLib.Factory.Impl;

namespace SquareLib.Extensions;

public static class CalculatorDIExtensions 
{
    public static IServiceCollection AddAreaCalculators(this IServiceCollection services, Action<ConfigurationBuilder>? builder = null)
    {
        services.AddTransient<ICalculatorFactory, DICalculatorFactory>();
        services.AddCalculators();
        services.AddConfiguratedCalculators(builder);
        return services;
    } 

    private static IServiceCollection AddConfiguratedCalculators(this IServiceCollection services, Action<ConfigurationBuilder>? builder = null)
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
            services.AddTransient(GetServiceType(type.Type), (services) => type.Calculator);
        }

        return services;
    }

    private static Type GetServiceType(Type type)
    {
        var calculatorInterface = typeof(IAreaCalculator<>);   
        return calculatorInterface.MakeGenericType(type);
    }
}
