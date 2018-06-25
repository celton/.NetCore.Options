using Lab.Celton.Core.Options.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab.Celton.Core.Options.Configurations
{
    public static class AppSettingsOptionsConfigurations
    {
        private static List<string> AccessTestList => new List<string>() { "AccessTestOne", "AccessTestTwo" };
        private static string AuthenticateTest => "AuthenticateTest";

        public static IConfiguration GetConfigAppSettingsFiles(this IConfigurationBuilder configurationBuilder)
        {
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            configurationBuilder.SetBasePath(Path.Combine(AppContext.BaseDirectory)).AddJsonFile("appsettings/appsettings.json", optional: false, reloadOnChange: true);

            if (!string.IsNullOrWhiteSpace(environment))
                configurationBuilder.AddJsonFile($"appsettings/appsettings.{environment}.json", optional: true, reloadOnChange: true);

            configurationBuilder.AddEnvironmentVariables();

            return configurationBuilder.Build();
        }

        public static IServiceCollection BindAppSettingsOptions(this IServiceCollection serviceCollection)
        {
            IConfiguration configuration = new ConfigurationBuilder().GetConfigAppSettingsFiles();

            serviceCollection.AddOptions();

            /// <wrong_code_1>
            /// You can't Configure two differents sections into same Option - but otherwise...
            /// </wrong_code_1>
            //foreach (var serviceTestItem in ServiceTestList)
            //    serviceCollection.Configure<ServiceTestOptions>(options => configuration.GetSection(serviceTestItem).Bind(options));

            if (AccessTestList.Any())
                serviceCollection.Configure<AccessOptions>(options => configuration.GetSection(AccessTestList.First()).Bind(options));

            serviceCollection.Configure<AuthenticateOptions>(options => configuration.GetSection(AuthenticateTest).Bind(options));

            return serviceCollection;
        }
    }
}
