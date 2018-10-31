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
    using Qualysoft.Evaluation.Data;
    using Swashbuckle.AspNetCore.Filters;
    using Swashbuckle.AspNetCore.Swagger;
    using System;
    using System.IO;
    using System.Reflection;

    public class Startup
    {
        const string NAME = "Qualysoft.Evaluation.Api";
        const string V1 = "v1";

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
            if (Environment.IsDevelopment())
            {
                // Development service configuration
                var logger = LoggerFactory.CreateLogger<Startup>();
                logger.LogInformation("Development environment");
            }

            services.AddDbContext<EvaluationContext>(opt => opt.UseInMemoryDatabase("TodoList"));
            
            services.AddMvcCore();

            services
                .AddMvc(options => 
                {
                    options.RespectBrowserAcceptHeader = true;
                    options.Filters.Add(typeof(GlobalExceptionFilterWithLoggingAttribute));
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddMemoryCache();

            services.AddSwaggerExamples();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(V1, new Info
                {
                    Title = $"{NAME} {V1}",
                    Version = V1,
                    Contact = new Contact { Email = "andrei.ciprian@gmail.com", Name = "Andrei Ciprian Popescu", Url = "http://andreipopescu.tk/" },
                    Description = "A simple ASP.NET Core Web API",
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
                // c.OperationFilter<ExamplesOperationFilter>();
            });


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // 

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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", NAME);
                c.RoutePrefix = string.Empty;
            });

            app.UseMvc();
        }
    }
}
