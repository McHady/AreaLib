using Microsoft.Extensions.DependencyInjection;
using SquareLib.Calculator;

namespace SquareLib.Factory.Impl;

internal class DICalculatorFactory : ICalculatorFactory
{
    private readonly IServiceProvider services;

    public DICalculatorFactory(IServiceProvider services)
    {
        this.services = services;
    }

    public IAreaCalculator<T> Build<T>() => services.GetService<IAreaCalculator<T>>() ?? throw new NotImplementedException(typeof(T).Name);
}

