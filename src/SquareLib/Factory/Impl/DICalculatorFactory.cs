using AreaLib.Calculator;
using Microsoft.Extensions.DependencyInjection;

namespace AreaLib.Factory.Impl;

internal class DICalculatorFactory : ICalculatorFactory
{
    private readonly IServiceProvider services;

    public DICalculatorFactory(IServiceProvider services)
    {
        this.services = services;
    }

    public IAreaCalculator<T> Build<T>() => services.GetService<IAreaCalculator<T>>() ?? throw new NotImplementedException(typeof(T).Name);
}

