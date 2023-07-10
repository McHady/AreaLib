using SquareLib.Calculator.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareLib.Calculator.Impl;

internal class CircleAreaByRadiusCalculator : IAreaCalculator<CircleWithRadius>
{
    public double Calculate(CircleWithRadius input) 
        => input.Radius >= 0 ?
            Math.PI * Math.Pow(input.Radius, 2)
            : throw new ArgumentOutOfRangeException(nameof(input));
}

