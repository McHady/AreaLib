using SquareLib;
using SquareLib.Calculator;
using Xunit;

namespace AreaLib.Tests
{
    public class ConfigurationTest
    {
        private record UnexpectedInput(double Data);

        private record TestInput(double Data);

        private class TestCalculator : IAreaCalculator<TestInput>
        {
            public double Calculate(TestInput input) => input.Data;
        }

        [Fact]
        public void CalculatorConfig_IsNewCalculatorAdded()
        {
            var factory = CalculatorFactoryBuilder.CreateFactory(config =>
            {
                config.WithCalculator<TestInput, TestCalculator>();
            });

            var calculator = factory.Build<TestInput>();
            TestInput input = new(0.55);
            Assert.Equal(input.Data, calculator.Calculate(input));
        }

        [Fact]
        public void CalculatorFactoryThrowsNotImplementedIfNoSpecifiedCalculatorAdded()
        {
            Assert.Throws<NotImplementedException>(() => CalculatorFactoryBuilder.CreateFactory(config =>
            {
                config.WithCalculator<TestInput, TestCalculator>();
            }).Build<UnexpectedInput>());
        }
    }
}