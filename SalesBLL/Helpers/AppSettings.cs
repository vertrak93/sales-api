using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBLL.Helpers
{
    public class AppSettings
    {
        private readonly string _keyJWT = string.Empty;
        public string KeyJWT { get => _keyJWT; }

        public AppSettings() 
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();

            _keyJWT = root.GetSection("JWT").GetSection("Key").Value;

        }
    }
}
