using Microsoft.Extensions.DependencyInjection;
using SquareLib.Calculator;
using SquareLib.Factory;
using SquareLib.Factory.Impl;

namespace SquareLib.Extensions;

public static class CalculatorDIExtensions 
{
    public static IServiceCollection AddAreaCalculators(this IServiceCollection services)
    {
        services.AddTransient<ICalculatorFactory, DICalculatorFactory>();
        services.AddCalculators();
        return services;
    }  
}
