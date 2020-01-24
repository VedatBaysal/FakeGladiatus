using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore;

namespace FakeGladiatus
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            CreateWebHostBuilder(args).Build().Run();
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args) =>

            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>(); 


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                    var appSettings = configuration.Get<AppSettings>();
                    webBuilder.UseConfiguration(configuration);
                    webBuilder.UseUrls(appSettings.ConnectionSettings.Address + ":" + appSettings.ConnectionSettings.Port);
                    webBuilder.ConfigureServices(x => x.AddSingleton(appSettings));
                    webBuilder.UseStartup<Startup>();
                });

    }
}
