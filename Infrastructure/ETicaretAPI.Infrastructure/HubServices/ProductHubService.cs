using ETicaretAPI.Application.Services;
using ETicaretAPI.Infrastructure.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure.HubServices
{
    public class ProductHubService : IProductHubService
    {
        readonly IHubContext<ProductHub> _hubContext;
        public const string ProductAddedMessage = "receiveProductAddedMessage";

        public ProductHubService(IHubContext<ProductHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task ProductAddedMessageAsync(string receiver, string message)
        {
            await _hubContext.Clients.Users(receiver).SendAsync(ProductAddedMessage, message);
        }
    }
}
