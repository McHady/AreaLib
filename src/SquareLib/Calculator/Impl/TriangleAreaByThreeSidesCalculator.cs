using AreaLib.Calculator.Inputs;

namespace AreaLib.Calculator.Impl
{
    internal class TriangleAreaByThreeSidesCalculator : IAreaCalculator<TriangleWithThreeSides>
    {
        public double Calculate(TriangleWithThreeSides input)
        {
            if (input.SideA < 0 || input.SideB < 0 || input.SideC < 0)
                throw new ArgumentOutOfRangeException(nameof(input));

            return IsRightTriangle(input) ?
                RightTriangleArea(input) :
                HeronsTriangleArea(input);
        }

        private static double HeronsTriangleArea(TriangleWithThreeSides input)
        {
            var semiPerimeter = (input.SideA + input.SideB + input.SideC) / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - input.SideA) * (semiPerimeter - input.SideB) * (semiPerimeter - input.SideC));    
        }

        private static bool IsRightTriangle(TriangleWithThreeSides input) => 
            IsRightTriangle(input.SideA, input.SideB, input.SideC) 
            || IsRightTriangle(input.SideC, input.SideA, input.SideB) 
            || IsRightTriangle(input.SideC, input.SideB, input.SideA);

        private static bool IsRightTriangle(double leg1, double leg2, double hypotenuse) 
            => Math.Pow(leg1, 2) + Math.Pow(leg2, 2) == Math.Pow(hypotenuse, 2);

        private static double RightTriangleArea(TriangleWithThreeSides input) 
            => new[] { input.SideA, input.SideB, input.SideC }.OrderBy(i => i).Take(2).Aggregate((a, b) => a * b) / 2;
    }
}
