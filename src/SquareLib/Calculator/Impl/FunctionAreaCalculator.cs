namespace AreaLib.Calculator.Impl
{
    internal class FunctionAreaCalculator<TInput> : IAreaCalculator<TInput>
    {
        private readonly Func<TInput, double> _func;

        public FunctionAreaCalculator(Func<TInput, double> areaCalculator) 
        { 
            _func = areaCalculator;
        }
        public double Calculate(TInput input)
            => _func!.Invoke(input);
    }
}
