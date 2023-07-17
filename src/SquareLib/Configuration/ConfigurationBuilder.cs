using SquareLib.Calculator;
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
    }

    public ConfigurationBuilder WithCalculator<TInput, TCalculator>() where TCalculator : IAreaCalculator<TInput>
    {
        this.AddedCalculatorTypes.Add(new (typeof(TInput), typeof(TCalculator)));
        return this;
    } 

    internal IList<CalculatorTypePair> AddedCalculatorTypes { get; set; }
}
