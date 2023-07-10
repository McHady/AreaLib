using SquareLib;
using SquareLib.Calculator;
using SquareLib.Calculator.Inputs;
using Xunit;

namespace AreaLib.Tests
{
    public class TriangleByThreeSidesTests
    {
        private readonly IAreaCalculator<TriangleWithThreeSides> _sut = CalculatorFactoryBuilder.CreateFactory().Build<TriangleWithThreeSides>();

        [Theory]
        [InlineData(5f, 6f, 7f, 14.69694f)]
        [InlineData(0f, 0f, 0f, 0f)]
        [InlineData(3.14f, 4.72f, 5.00f, 7.19233f)]
        [InlineData(3f, 5f, 4f, 6f)] // прямоугольный треугольник
        public void Calculator_IsAreaRight(double a, double b, double c, double expected)
        {
            Assert.Equal(expected, _sut.Calculate(new (a, b, c)), 0.0001);
        }

        [Fact]
        public void Calculator_ThrowsExceptionIfNegativeInput()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _sut.Calculate(new(-1, 0, 26)));
        }
    }
}