using SquareLib.Calculator;

namespace SquareLib.Factory;

public interface ICalculatorFactory
{
    public IAreaCalculator<T> Build<T>();
}

