using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Services;
using ETicaretAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
    {
        readonly private IProductRepository _productRepository;
        readonly IProductHubService _productHubService;
        public CreateProductCommandHandler(IProductRepository productRepository, IProductHubService productHubService)
        {
            _productRepository = productRepository;
            _productHubService = productHubService;
        }

        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            await _productRepository.AddAsync(new Product()
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock,
            });
            await _productHubService.ProductAddedMessageAsync($"{request.Name} isminde product eklendi.", "user@example.com");
            await _productRepository.SaveAsync();
            return true;
        }
    }
}
