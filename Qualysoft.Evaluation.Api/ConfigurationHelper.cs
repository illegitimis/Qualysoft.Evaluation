namespace Qualysoft.Evaluation.Api
{
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;

    [ExcludeFromCodeCoverage]
    internal static class ConfigurationHelper
    {
        public const string Stub = "Stub";
        public const string Development = "Development";
        public const string Production = "Production";

        public const string AspnetcoreEnvironment = "ASPNETCORE_ENVIRONMENT";

        public static IConfiguration Configuration => CreateConfiguration(Directory.GetCurrentDirectory());

        internal static IConfiguration CreateConfiguration(string basePath) => new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable(AspnetcoreEnvironment) ?? Stub}.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable(AspnetcoreEnvironment) ?? Production}.json", optional: true, reloadOnChange: true)
            .Build();
    }
    
}
