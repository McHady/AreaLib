using AreaLib.Calculator;

namespace AreaLib.Factory;

public interface ICalculatorFactory
{
    public IAreaCalculator<T> Build<T>();
}

