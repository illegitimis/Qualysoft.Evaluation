namespace Qualysoft.Evaluation.Api
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args)
                .Build()
                .Run();
        }

        /// <summary>
        /// Initialize <see cref="WebHostBuilder"/>.
        /// </summary>
        /// <param name="args">args</param>
        /// <returns><see cref="IWebHostBuilder"/> realization.</returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseConfiguration(ConfigurationHelper.Configuration)
                .UseKestrel()
                .CaptureStartupErrors(true);
    }

    
}
