using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BattletiteAPI.Repositories;
using BattletiteAPI.Models;
using MongoDB.Bson.Serialization;

namespace BattletiteAPI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddMvc();

            services.AddSwaggerGen();

            // Mongo register class maps
            RegisterMongoClassMaps();

            // Register Repos
            services.AddScoped<IRepo<Battlerite, Battlerite>, BattleritesRepo>();
            services.AddScoped<IRepo<Champion, Champion>, ChampionsRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));

            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUi();
        }

        private static void RegisterMongoClassMaps()
        {
            BsonClassMap.RegisterClassMap<Battlerite>();
            BsonClassMap.RegisterClassMap<BattleriteMeta>();
            BsonClassMap.RegisterClassMap<Champion>();
            BsonClassMap.RegisterClassMap<ChampionPool>();
            BsonClassMap.RegisterClassMap<Opponent>();
        }
    }
}
