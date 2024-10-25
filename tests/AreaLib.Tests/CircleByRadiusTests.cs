using AreaLib.Calculator;
using AreaLib.Calculator.Inputs;

namespace AreaLib.Tests
{
    public class CircleByRadiusTests
    {
        private readonly IAreaCalculator<CircleWithRadius> _sut = CalculatorFactoryBuilder.CreateFactory().Build<CircleWithRadius>();

        [Theory]
        [InlineData(1f, Math.PI)]
        [InlineData(3, Math.PI * 3 * 3)]
        [InlineData(3.4, Math.PI * 3.4 * 3.4)]
        public void Calculator_IsAreaRight(double radius, double expected)
        {
            Assert.Equal(expected, _sut.Calculate(new(radius)), 0.0001);
        }

        [Fact]
        public void Calculator_ThrowsExceptionIfNegativeInput()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _sut.Calculate(new(-5)));
        }
    }
}
