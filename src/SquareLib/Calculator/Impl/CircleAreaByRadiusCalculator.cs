using AreaLib.Calculator.Inputs;

namespace AreaLib.Calculator.Impl;

internal class CircleAreaByRadiusCalculator : IAreaCalculator<CircleWithRadius>
{
    public double Calculate(CircleWithRadius input) 
        => input.Radius >= 0 ?
            Math.PI * Math.Pow(input.Radius, 2)
            : throw new ArgumentOutOfRangeException(nameof(input));
}

