using SquareLib.Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareLib.Factory;

public interface ICalculatorFactory
{
    public IAreaCalculator<T> Build<T>();
}

