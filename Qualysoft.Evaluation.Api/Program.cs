namespace Qualysoft.Evaluation.Api
{
    using Autofac.Extensions.DependencyInjection;
    using DbUp;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Qualysoft.Evaluation.Data;
    using SimpleMigrations;
    using SimpleMigrations.DatabaseProvider;
    using System;
    using System.Data.SqlClient;

    /// <summary>web api entry point</summary>
    public class Program
    {
        /// <remarks>Sonar lint warning</remarks>
        protected Program() { }

        /// <summary>Run web app from console</summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            IWebHost host = CreateWebHostBuilder(args).Build();

            AutomaticMigrations(host);

            host.Run();
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

        private static void AutomaticMigrations(IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var ctx = scope.ServiceProvider.GetRequiredService<EvaluationContext>();
                var db = ctx.Database;

                try
                {
                    if (db.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
                        db.Migrate();
                }
                catch (Exception ex)
                {
                    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "EFCore Database Migrate error");
                    foreach (var migration in db.GetAppliedMigrations())
                        logger.LogInformation(migration);

                    try
                    {
                        SimpleMigrations();
                    }
                    catch
                    {
                        logger.LogError(ex, nameof(SimpleMigrations));
                        var dbupex = DbUp();
                        if (dbupex != null)
                        {
                            logger.LogError(dbupex, nameof(DbUp));
                        }
                    }
                }
            }
        }

        private static Exception DbUp()
        {
            var upgrader = DeployChanges.To
                .SqlDatabase(ConnectionString())
                .WithScriptsEmbeddedInAssembly(typeof(Data.Migrations.InitialCreate).Assembly)
                .LogToConsole()
                .Build();

            var result = upgrader.PerformUpgrade();

            return result.Error;
        }

        private static void SimpleMigrations()
        {
            using (var dbCon = new SqlConnection(ConnectionString()))
            {
                var databaseProvider = new MssqlDatabaseProvider(dbCon);
                var migrator = new SimpleMigrator(typeof(Data.Migrations.BogusFakerSeed).Assembly, databaseProvider);
            
                //interact directly with the migrator...
                migrator.Load();
                migrator.MigrateToLatest();
            }
        }

        private static string ConnectionString() => ConfigurationHelper.Configuration.GetConnectionString("SqlServer");
    }


}
