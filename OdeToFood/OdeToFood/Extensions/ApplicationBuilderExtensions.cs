using Microsoft.Extensions.FileProviders;
using System.IO;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseNodeModules(this IApplicationBuilder app, string rootPath)
        {
            // Combine the rootpath to the node_modules to get the absolute path
            var path = Path.Combine(rootPath, "node_modules");
            var fileProvider = new PhysicalFileProvider(path);
            var options = new StaticFileOptions
            {
                RequestPath = "/node_modules",
                FileProvider = fileProvider
            };
            app.UseStaticFiles(options);
            return app;
        }
    }
}
