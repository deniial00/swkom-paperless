using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace NPaperless.Services;

/// <summary>
/// Program
/// </summary>
public class Program
{
    /// <summary>
    /// Main
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        var builder = Host.CreateDefaultBuilder();
        
        // add logger
        builder.ConfigureLogging( logging => 
        {
            logging.AddConsole();
            logging.ClearProviders();
        });

        // configer builder
        builder.ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>()
                        .UseUrls("http://0.0.0.0:8080/");
        });
        
        builder.Build().Run();
    }
}
