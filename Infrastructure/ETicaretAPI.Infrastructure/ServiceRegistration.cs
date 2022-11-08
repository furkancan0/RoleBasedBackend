using ETicaretAPI.Application.Services;
using ETicaretAPI.Infrastructure.HubServices;
using ETicaretAPI.Infrastructure.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
            serviceCollection.AddScoped<IMailService, MailService>();

            serviceCollection.AddTransient<IProductHubService, ProductHubService>();
            serviceCollection.AddSignalR();
            serviceCollection.AddSingleton<IUserIdProvider, CustomEmailProvider>();
        }
    }
}
