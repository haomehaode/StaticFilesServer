using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace StaticFilesServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region 手机访问需要加Http://ip:5000
            //var host = new WebHostBuilder()
            //       .UseKestrel()
            //       .UseContentRoot(Directory.GetCurrentDirectory())
            //       .UseIISIntegration()
            //       .UseUrls("http://*:5000")
            //       .UseStartup<Startup>()
            //       .Build();
            //host.Run(); 
            #endregion
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
