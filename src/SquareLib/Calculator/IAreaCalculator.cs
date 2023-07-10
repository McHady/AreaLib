using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareLib.Calculator;

public interface IAreaCalculator<T>
{
    double Calculate(T input);   
}

