namespace SquareLib.Calculator.Impl
{
    internal class FunctionAreaCalculator<TInput> : IAreaCalculator<TInput>
    {
        private readonly Func<TInput, double> funct;

        public FunctionAreaCalculator(Func<TInput, double> areaCalculator) 
        { 
            this.funct = areaCalculator;
        }
        public double Calculate(TInput input)
            => funct!.Invoke(input);
    }
}
