using AreaLib.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SquareLib.Extensions;
using SquareLib.Factory;

namespace SquareLib
{
    public static class CalculatorFactoryBuilder // точка входа, если в консюмере не используется DI
    {
        public static ICalculatorFactory CreateFactory(Action<ConfigurationBuilder>? builder = null)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAreaCalculators(builder);
            return serviceCollection.BuildServiceProvider().GetRequiredService<ICalculatorFactory>();
        }
    }
}
