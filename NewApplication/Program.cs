using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
            //var host = CreateWebHostBuilder(args);
            //using (var scope = host.)
        }

        //public static IHostBuilder CreateHostBuilder(string[] args)
        // =>Host.CreateDefaultBuilder(args)
        //     .ConfigureWebHostDefaults(
        //         webBuilder => webBuilder.UseStartup<Startup>());
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) => 
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();
        //So to allow migration on 3.0 i had to change the IHostBuilder to IWebHostBuilder
    }
}
