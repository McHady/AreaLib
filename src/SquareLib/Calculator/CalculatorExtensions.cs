using Microsoft.Extensions.DependencyInjection;
using SquareLib.Calculator.Impl;
using SquareLib.Calculator.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
