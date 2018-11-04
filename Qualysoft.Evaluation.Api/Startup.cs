namespace Qualysoft.Evaluation.Api
{
    using Autofac;
    using Autofac.Extensions.DependencyInjection;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Qualysoft.Evaluation.Api.Filters;
    using Qualysoft.Evaluation.Application;
    using Qualysoft.Evaluation.Application.Xml;
    using Qualysoft.Evaluation.Data;
    using Qualysoft.Evaluation.Domain;
    using Swashbuckle.AspNetCore.Filters;
    using Swashbuckle.AspNetCore.Swagger;
    using System;
    using System.IO;
    using System.Reflection;

    /// <summary>bootstraps the app</summary>
    public class Startup
    {
        const string NAME = "Qualysoft.Evaluation.Api";
        const string V1 = "v1";
        const string SWAGGER_ENDPOINT_URL_KEY = "SwaggerEndpointUrl";
        const string DESCRIPTION = "A simple ASP.NET Core Web API";
        const string ERROR_HANDLING_PATH = "/error";

        /// <summary />
        public Startup(IHostingEnvironment env, IConfiguration config, ILoggerFactory loggerFactory)
        {
            Configuration = config;
            Environment = env;
            LoggerFactory = loggerFactory;
        }

        /// <summary />
        public IConfiguration Configuration { get; }
        /// <summary />
        public IHostingEnvironment Environment { get; }
        /// <summary />
        public ILoggerFactory LoggerFactory { get; }

        #region Configure<EnvironmentName>Services

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">Service descriptors collection</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore();

            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.Filters.Add(typeof(GlobalExceptionFilterWithLoggingAttribute));
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(V1, new Info
                {
                    Title = $"{NAME} {V1}",
                    Version = V1,
                    Contact = new Contact { Email = "andrei.ciprian@gmail.com", Name = "Andrei Ciprian Popescu", Url = "http://andreipopescu.tk/" },
                    Description = DESCRIPTION,
                    TermsOfService = "<TermsOfService>",
                    License = new License { Name = "BSD 3-Clause", Url = "https://github.com/domaindrivendev/Swashbuckle/blob/master/LICENSE" }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                if (File.Exists(xmlPath)) c.IncludeXmlComments(xmlPath);

                // ConfigureSwaggerGen
                c.DescribeAllEnumsAsStrings();
                c.DescribeAllParametersInCamelCase();
                c.DescribeStringEnumsInCamelCase();
                c.IgnoreObsoleteActions();
                c.IgnoreObsoleteProperties();
            });

            services.AddSwaggerExamples();
        }

        /// <summary>Configure Staging Services</summary>
        /// <param name="services"></param>
        /// <remarks>Intentionally left without any IoC service registrations</remarks>
        public void ConfigureStagingServices(IServiceCollection services)
        {
            if (!Environment.IsStaging())
            {
                throw new EnvironmentMismatchException(Environment.EnvironmentName);
            }

            services.AddDbContext<EvaluationContext>(options => options.UseSqlite("hoist.db"));

            ConfigureServices(services);
        }

        /// <summary>
        /// Development service configuration
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            if (!Environment.IsDevelopment())
            {
                throw new EnvironmentMismatchException(Environment.EnvironmentName);
            }

            var logger = LoggerFactory.CreateLogger<Startup>();
            logger.LogInformation("Development environment");

            // Microsoft.Extensions.DependencyInjection & in memory db for deveopment
            services.AddDbContext<EvaluationContext>(opt => opt.UseInMemoryDatabase("Hoist"));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAsyncRepository<Request, int>, EFRepository<EvaluationContext, Request, int>>();
            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<IBackgroundJobRunner, BackgroundJobRunner>();
            services.AddScoped<ISerializeXml, AppDataFileRequestXmlSerializer>();
            services.AddSingleton<IClassMapper<Request, CT_XSD_Request>, DomainToXmlSerializedRequestMapper>();
            
            ConfigureServices(services);
        }

        /// <summary>Production services configuration</summary>
        /// <param name="services"></param>
        public void ConfigureProductionServices(IServiceCollection services)
        {
            if (!Environment.IsProduction())
            {
                throw new EnvironmentMismatchException(Environment.EnvironmentName);
            }

            // autofac & sql server db for production
            services.AddAutofac(builder => builder.RegisterModule<AutofacModule>());
            services.AddDbContext<EvaluationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlServer")));

            ConfigureServices(services);
        }
        
        #endregion

        #region Configure<EnvironmentName>Container

        /// <summary>
        /// Register things directly with Autofac, only for production environment
        /// This runs after ConfigureServices so the things here will override registrations made in ConfigureServices.
        /// </summary>
        /// <param name="builder">Autofac Container builder</param>
        public void ConfigureProductionContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacModule());
        }

        #endregion

        #region Configure<EnvironmentName>

        /// <summary>Called by the runtime. Configure the HTTP request pipeline.</summary>
        /// <param name="app">configures request pipeline</param>
        /// <param name="env">web hosting environment</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStatusCodePagesWithRedirects($"{ERROR_HANDLING_PATH}/{0}");

            app.UseStaticFiles();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(Configuration.GetValue<string>(SWAGGER_ENDPOINT_URL_KEY), NAME);
                c.RoutePrefix = string.Empty;
                c.DocExpansion(DocExpansion.List);
                c.DisplayRequestDuration();
                c.DocumentTitle = DESCRIPTION;
            });

            app.UseMvc();
        }

        /// <summary>Called before <see cref="Configure"/> for development environment</summary>
        /// <param name="app">request pipeline configurator</param>
        /// <param name="env">web hosting environment</param>
        public void ConfigureDevelopment(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (!env.IsDevelopment()) return;

            LoggerFactory.AddConsole(this.Configuration.GetSection("Logging"));
            LoggerFactory.AddDebug();
            
            app.UseDeveloperExceptionPage();

            Configure(app, env);
        }

        /// <summary />
        public void ConfigureStaging(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (!env.IsStaging()) return;
            app.UseExceptionHandler(ERROR_HANDLING_PATH);
            Configure(app, env);
        }

        /// <summary />
        public void ConfigureProduction(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (!env.IsProduction()) return;
            app.UseExceptionHandler(ERROR_HANDLING_PATH);
            Configure(app, env);
        }

        #endregion
    }
}
