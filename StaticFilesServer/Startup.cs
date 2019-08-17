using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace StaticFilesServer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            #region 文件夹访问
            services.AddDirectoryBrowser(); 
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
         
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            #region 访问文件夹和文件
            var dir = new DirectoryBrowserOptions();
            dir.FileProvider = new PhysicalFileProvider(@"G:\");
            app.UseDirectoryBrowser(dir);//文件夹
            var staticfile = new StaticFileOptions();
            staticfile.FileProvider = new PhysicalFileProvider(@"G:\");
            staticfile.ServeUnknownFileTypes = true;
            staticfile.DefaultContentType = "application/x-msdownload";//设置默认MIME Type
            var provider = new FileExtensionContentTypeProvider();
            provider.Mappings.Add(".log","text/plain");//手动设置对应MIME Type
            staticfile.ContentTypeProvider = provider;
            app.UseStaticFiles(staticfile); //文件
            #endregion
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
