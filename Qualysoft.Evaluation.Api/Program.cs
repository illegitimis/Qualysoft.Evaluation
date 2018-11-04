namespace Qualysoft.Evaluation.Api
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Autofac.Extensions.DependencyInjection;

    /// <summary>web api entry point</summary>
    public class Program
    {
        /// <remarks>Sonar lint warning</remarks>
        protected Program() { }

        /// <summary>Run web app from console</summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args)
                .Build()
                .Run();
        }

        /// <summary>Initialize <see cref="WebHostBuilder"/>.</summary>
        /// <param name="args">args</param>
        /// <returns><see cref="IWebHostBuilder"/> realization.</returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .CaptureStartupErrors(true)
                .ConfigureServices(services => services.AddAutofac())
                .UseConfiguration(ConfigurationHelper.Configuration)
                .UseKestrel()
                .UseStartup<Startup>();
    }


}
