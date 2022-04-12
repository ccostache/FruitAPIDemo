using System;
using FruitApi.Configuration;
using FruitApi.DTO.Endpoints.Mapping;
using FruitApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace FruitApi
{
    public class Startup
    {
        /// <summary>
        /// Gets and sets the logger
        /// </summary>
        public ILogger Logger { get; set; }

        private readonly NLogLoggerProvider LoggerProvider;

        /// <summary>
        /// Initialise a new instance of the Startup class
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="loggerFactory"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            LoggerProvider = new NLogLoggerProvider();

            Logger = LoggerProvider.CreateLogger(nameof(Startup));
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            try
            {
                Logger.LogInformation("Startup - configuring services");

                // FruitApi service reistration
                var fruitApiConfig = Configuration.GetSection(UrlSettings.SectionName);
                services.Configure<UrlSettings>(fruitApiConfig);

                services.AddHttpClient();
                services.AddScoped<IFruitService, FruitService>();

                // using AutoMapper.Extensions.Microsoft.Dependencyinjection for mapping
                services.AddAutoMapper(typeof(FruitProfileService));

                // TODO: Add options and encryptions helper services to the DI
                // TODO: Add proxy configuration
                // TODO: Add Authorization configuration: need to wireup the service that does the API authentication and authorization
                // TODO: Add Acess token management policies and authorization policies (see Policies)

                services.AddControllers();
                services.AddSwaggerGen();
            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, "An Exception occured during startup. The exception was: {0}\n", ex.ToString());
                throw;
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            // Register exception handling middleware
            // app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
