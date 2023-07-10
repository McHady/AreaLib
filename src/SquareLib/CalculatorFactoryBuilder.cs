using Microsoft.Extensions.DependencyInjection;
using SquareLib.Extensions;
using SquareLib.Factory;

namespace SquareLib
{
    public static class CalculatorFactoryBuilder // точка входа, если в консюмере не используется DI
    {
        public static ICalculatorFactory CreateFactory()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAreaCalculators();
            return serviceCollection.BuildServiceProvider().GetRequiredService<ICalculatorFactory>();
        }
    }
}
