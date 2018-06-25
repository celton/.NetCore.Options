using Lab.Celton.Core.Options.Configurations;
using Microsoft.Extensions.DependencyInjection;
using System;
using Lab.Celton.Core.Options.Services.Contract;

namespace Lab.Celton.Core.Options
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceProvider serviceProvider = new ServiceCollection().ConfigureDI().BindAppSettingsOptions().BuildServiceProvider();

            var myTestService = serviceProvider.GetService<IMyTestService>();

            Console.WriteLine("Endpoint: " + myTestService.GetAccessPoint());
            Console.WriteLine("Credential:\n\t" + myTestService.GetCredencial());

            Console.ReadKey();
        }
    }
}
