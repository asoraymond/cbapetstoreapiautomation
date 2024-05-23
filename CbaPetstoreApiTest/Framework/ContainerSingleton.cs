using CbaPetstoreApiTest.Framework.APIMethods;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CbaPetstoreApiTest.Framework
{
    public class ContainerSingleton
    {
        public static IServiceProvider ConfigureServices()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration configuration = builder.Build();

            var serviceCollection = new ServiceCollection();

            serviceCollection.AddOptions();

            serviceCollection.Configure<AppSettings>(configuration.GetSection("AppSettings"));

            serviceCollection.AddSingleton<IApiCalls>(sp =>
            {
                var appSettings = sp.GetService<IOptions<AppSettings>>().Value;
                return new ApiCalls(appSettings.BaseUrl);
            });

            return serviceCollection.BuildServiceProvider();
        }
    }
}
