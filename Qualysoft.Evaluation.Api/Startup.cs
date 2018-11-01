namespace Qualysoft.Evaluation.Api
{
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
    using Qualysoft.Evaluation.Data;
    using Qualysoft.Evaluation.Domain;
    using Swashbuckle.AspNetCore.Filters;
    using Swashbuckle.AspNetCore.Swagger;
    using System;
    using System.IO;
    using System.Reflection;

    public class Startup
    {
        const string NAME = "Qualysoft.Evaluation.Api";
        const string V1 = "v1";
        const string SWAGGER_ENDPOINT_URL_KEY = "SwaggerEndpointUrl";
        const string DESCRIPTION = "A simple ASP.NET Core Web API";

        public Startup(IHostingEnvironment env, IConfiguration config, ILoggerFactory loggerFactory)
        {
            Configuration = config;
            Environment = env;
            LoggerFactory = loggerFactory;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }
        public ILoggerFactory LoggerFactory { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">Service descriptors collection</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EvaluationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlServer")));

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

            // TODO: Autofac
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAsyncRepository<Request, int>, EFRepository<EvaluationContext, Request, int>>();
            services.AddScoped<IRequestService, RequestService>();
        }

        /*
        /// <summary>
        /// Configure Staging Services
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureStagingServices(IServiceCollection services)
        {
            if (!Environment.IsStaging())
            {
                throw new BasketNotFoundException(13);
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
                throw new BasketNotFoundException(17);
            }
            
            var logger = LoggerFactory.CreateLogger<Startup>();
            logger.LogInformation("Development environment");
            services.AddDbContext<EvaluationContext>(opt => opt.UseInMemoryDatabase("Hoist"));

            ConfigureServices(services);
        }

        /// <summary>
        /// Development service configuration
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureProductionServices(IServiceCollection services)
        {
            if (!Environment.IsProduction())
            {
                throw new BasketNotFoundException(11);
            }

            services.AddDbContext<EvaluationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlServer")));

            ConfigureServices(services);
        }
        */


        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">configures request pipeline</param>
        /// <param name="env">web hosting environment</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // app.UseBrowserLink();
            }
            else
            {
                // app.UseHsts();
                app.UseExceptionHandler("/error");
            }

            // app.DisableOptionsVerb();

            // app.UseHttpsRedirection();

            // app.UseStatusCodePages();
            app.UseStatusCodePagesWithRedirects("/error/{0}");

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
    }
}
