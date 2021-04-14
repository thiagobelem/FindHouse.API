using System;
using FindHouse.API.Extensions;
using Elmah.Io.AspNetCore;
using Elmah.Io.AspNetCore.HealthChecks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FindHouse.API.Configuration
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLoggingConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddElmahIo(o =>
            {
                o.ApiKey = "388dd3a277cb44c4aa128b5c899a3106";
                o.LogId = new Guid("c468b2b8-b35d-4f1a-849d-f47b60eef096");
            });

            // add elmah como provider, captura logs do aspnetcore (injetados manualmente _logger.LogWarning() etc...)
            //services.AddLogging(builder =>
            //{
            //    builder.AddElmahIo(o =>
            //    {
            //        o.ApiKey = "388dd3a277cb44c4aa128b5c899a3106";
            //        o.LogId = new Guid("c468b2b8-b35d-4f1a-849d-f47b60eef096");
            //    });
            //    builder.AddFilter<ElmahIoLoggerProvider>(null, LogLevel.Warning);
            //});

            //services.AddHealthChecks()
            //    .AddElmahIoPublisher(options =>
            //    {
            //        options.ApiKey = "388dd3a277cb44c4aa128b5c899a3106";
            //        options.LogId = new Guid("c468b2b8-b35d-4f1a-849d-f47b60eef096");
            //        options.HeartbeatId = "API Fornecedores";

            //    })
            //    .AddCheck("Imoveis", new SqlServerHealthCheck(configuration.GetConnectionString("DefaultConnection")))
            //    .AddSqlServer(configuration.GetConnectionString("DefaultConnection"), name: "BancoSQL");

            return services;
        }

        public static IApplicationBuilder UseLoggingConfiguration(this IApplicationBuilder app)
        {
            app.UseElmahIo();

            return app;
        }
    }
}
