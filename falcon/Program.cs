using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace evaporate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        =>
            Host.CreateDefaultBuilder(args)
                  .ConfigureWebHostDefaults(webBuilder =>
                  {
                      webBuilder.UseIIS();
                      webBuilder.UseStartup<Startup>();
                      webBuilder.UseStaticWebAssets();
                      webBuilder.UseContentRoot(ContentRoot());
                  });

        public static string ContentRoot()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return path;
        }
    }
}
