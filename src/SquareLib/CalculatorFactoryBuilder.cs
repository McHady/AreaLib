using AreaLib.Configuration;
using AreaLib.Extensions;
using AreaLib.Factory;
using Microsoft.Extensions.DependencyInjection;

namespace AreaLib
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
