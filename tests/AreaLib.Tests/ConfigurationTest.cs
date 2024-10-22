using SquareLib;
using SquareLib.Calculator;

namespace AreaLib.Tests
{
    using TestTupleInput = (double A, double B);

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
        public void CalculatorConfig_IsNewCalculatorImplementationAdded()
        {
            var factory = CalculatorFactoryBuilder.CreateFactory(config =>
            {
                config.WithCalculator<TestTupleInput>(input => input.A * input.B);
            });

            var calculator = factory.Build<TestTupleInput>();
            (double A, double B) input = (20, 10);

            Assert.Equal(input.A * input.B, calculator.Calculate(input));  
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