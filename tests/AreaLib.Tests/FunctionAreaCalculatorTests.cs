﻿using SquareLib;
using SquareLib.Calculator;

namespace AreaLib.Tests
{
    public class FunctionAreaCalculatorTests
    {
        private record Rectangle(double A, double B);

        private readonly IAreaCalculator<Rectangle> _sut = CalculatorFactoryBuilder.CreateFactory(builder => builder.WithCalculator<Rectangle>(input => input.A * input.B)).Build<Rectangle>();

        [Theory]
        [InlineData(2, 2, 4)]
        [InlineData(3, 3, 9)]
        [InlineData(1, 2, 2)]
        [InlineData(242, 4233, 1_024_386)]
        public void Calculator_IsAreaRight(double a, double b, double expected)
        {
            Assert.Equal(expected, _sut.Calculate(new(a, b)), 0.0001);
        }
    }
}