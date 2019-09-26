
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace linkservicenet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<Startup>();
                    // the following is used to disable https
                    webBuilder.UseKestrel(options => {
                        options.Listen(System.Net.IPAddress.Parse("0.0.0.0"), 5000);
                    });
                });

        
    }
}
