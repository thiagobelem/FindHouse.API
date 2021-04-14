using System;
using Microsoft.Extensions.DependencyInjection;
using FindHouse.Data.Context;
using FindHouse.Data.Repository;
using FindHouse.Business.Interfaces;
using FindHouse.Business.Notifications;
using FindHouse.Business.Services;
using Microsoft.AspNetCore.Http;
using FindHouse.API.Extensions;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FindHouse.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<FindHouseDBContext>();
            services.AddScoped<IAnuncianteRepository, AnuncianteRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IImovelRepository, ImovelRepository>();
            services.AddScoped<IAnuncianteService, AnuncianteService>();
            services.AddScoped<IImovelService, ImovelService>();

            services.AddScoped<INotifier, Notifier>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
