using Microsoft.Extensions.DependencyInjection;
using SquareLib.Calculator.Impl;
using SquareLib.Calculator.Inputs;

namespace SquareLib.Calculator
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
