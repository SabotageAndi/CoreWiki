using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CoreWiki
{
    public class Program 
    {
        public static void Main(string[] args)
        {
            var buildWebHost = BuildWebHost(args);
            buildWebHost.Run();
        }

        public static IWebHost BuildWebHost(string[] args) => CreateWebHost(args).Build();

        public static IWebHostBuilder CreateWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseApplicationInsights()
                .UseStartup<Startup>()
                .UseKestrel(options =>
                {
                    options.AddServerHeader = false;
                });
        }
    }
}
