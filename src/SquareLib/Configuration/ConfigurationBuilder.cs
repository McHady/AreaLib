using AreaLib.Calculator;
using AreaLib.Calculator.Impl;

namespace AreaLib.Configuration;

public class ConfigurationBuilder
{
    public ConfigurationBuilder()
    {
        this.AddedTypesWithCalculators = new List<TypeWithCalculatorPair>();
        this.AddedTypesWithImplementations = new List<TypeWithImplementationPair>();
    }

    public ConfigurationBuilder WithCalculator<TInput, TCalculator>() where TCalculator : IAreaCalculator<TInput>
    {
        this.AddedTypesWithCalculators.Add(new (typeof(TInput), typeof(TCalculator)));
        return this;
    }
    
    public ConfigurationBuilder WithCalculator<TInput>(IAreaCalculator<TInput> calculator)
    {
        this.AddedTypesWithImplementations.Add(new (typeof(TInput), calculator));
        return this;
    }

    public ConfigurationBuilder WithCalculator<TInput>(Func<TInput, double> calculatorFunct)
    {
        this.WithCalculator(new FunctionAreaCalculator<TInput>(calculatorFunct));
        return this;
    }

    internal List<TypeWithCalculatorPair> AddedTypesWithCalculators { get; set; }

    internal List<TypeWithImplementationPair> AddedTypesWithImplementations { get; }
}
