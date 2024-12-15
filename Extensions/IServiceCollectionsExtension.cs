using ErcasPay.Base;
using ErcasPay.Infrastructure.Http;
using ErcasPay.Services.BankTransferService;
using ErcasPay.Services.CardService;
using ErcasPay.Services.TransactionService;
using ErcasPay.Services.USSDService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ErcasPay.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class ServiceCollectionsExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IServiceCollection AddErcasPay(this IServiceCollection services, IConfiguration config)
        {
            // Base Dependency Injection
            services.AddScoped<IErcasPay, Base.ErcasPay>();

            // Services Dependency Injection
            services.AddScoped<IBankTransferService, BankTransferService>();
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<IUSSDService, USSDService>();
            services.AddScoped<ITransactionService, TransactionService>();

            // Infrastructure Dependency INjection
            services.AddScoped<IApiClient, ApiClient>();

            services.AddHttpClient();

            return services;
        }
    }
}