using Microsoft.Extensions.Configuration;
using System.IO;

namespace ApiRestCore.Utils
{
    public class JsonTools
    {
        public IConfigurationRoot ReadTokensAppsettings()
        {
            var builder = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile($"appsettings.json");
            var config = builder.Build();
            return config;
        }
    }
}
