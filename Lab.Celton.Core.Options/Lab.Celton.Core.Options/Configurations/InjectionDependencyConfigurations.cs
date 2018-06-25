using Lab.Celton.Core.Options.Services;
using Lab.Celton.Core.Options.Services.Contract;
using Microsoft.Extensions.DependencyInjection;

namespace Lab.Celton.Core.Options.Configurations
{
    public static class InjectionDependencyConfigurations
    {
        public static IServiceCollection ConfigureDI(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IMyTestService, MyTestService>();

            return serviceCollection;
        }
    }
}
