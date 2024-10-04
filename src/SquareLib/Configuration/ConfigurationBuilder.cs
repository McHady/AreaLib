using SquareLib.Calculator;
using SquareLib.Calculator.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaLib.Configuration;

public class ConfigurationBuilder
{
    public ConfigurationBuilder()
    {
        this.AddedCalculatorTypes = new List<CalculatorTypePair>();
        this.AddedCalculators = new List<CalculatorPair>();
    }

    public ConfigurationBuilder WithCalculator<TInput, TCalculator>() where TCalculator : IAreaCalculator<TInput>
    {
        this.AddedCalculatorTypes.Add(new (typeof(TInput), typeof(TCalculator)));
        return this;
    }
    
    public ConfigurationBuilder WithCalculator<TInput>(IAreaCalculator<TInput> calculator)
    {
        this.AddedCalculators.Add(new CalculatorPair(typeof(TInput), calculator));
        return this;
    }

    public ConfigurationBuilder WithCalculator<TInput>(Func<TInput, double> calculatorFunct)
    {
        this.WithCalculator(new FunctionAreaCalculator<TInput>(calculatorFunct));
        return this;
    }

    internal IList<CalculatorTypePair> AddedCalculatorTypes { get; set; }

    internal List<CalculatorPair> AddedCalculators { get; }
}
