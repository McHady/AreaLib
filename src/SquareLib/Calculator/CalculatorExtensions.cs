using AreaLib.Calculator.Impl;
using AreaLib.Calculator.Inputs;
using Microsoft.Extensions.DependencyInjection;

namespace AreaLib.Calculator
{
    internal static class CalculatorExtensions 
    {
        public static IServiceCollection AddCalculators(this IServiceCollection services)
        {
            services.AddTransient<IAreaCalculator<CircleWithRadius>, CircleAreaByRadiusCalculator>();
            services.AddTransient<IAreaCalculator<TriangleWithThreeSides>, TriangleAreaByThreeSidesCalculator>();
            return services;
        }
    }
}
