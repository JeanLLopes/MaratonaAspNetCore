using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FanSoftStore.UI.Infra
{
    public static class ApplicationBuilderExtensions
    {
        //FOR RETORN NPM FILES 
        public static IApplicationBuilder UseNodeModules(this IApplicationBuilder app, string rootFile)
        {
            //GET FOLDER WITH NODE MODULES ( INSTALLED BY NPM )
            var option = new StaticFileOptions();
            option.RequestPath = "/node_modules";
            var path = Path.Combine(rootFile, "node_modules");
            option.FileProvider = new PhysicalFileProvider(path);

            app.UseStaticFiles();
            return app;
        }
    }
}
