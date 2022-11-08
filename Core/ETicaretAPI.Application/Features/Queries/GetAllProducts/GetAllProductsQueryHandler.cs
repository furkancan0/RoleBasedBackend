using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.ViewModels.Products;
using MediatR;

namespace ETicaretAPI.Application.Features.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, GetAllProductsViewModel>
    {
        readonly private IProductRepository _productRepository;

        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<GetAllProductsViewModel> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var totalProductCount = _productRepository.GetAll(false).Count();
            var products = _productRepository.GetAll(false).Skip((request.Page-1) * request.Size).Take(request.Size).Select(p => new GetProductViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock
            }).ToList();

            return Task.FromResult(new GetAllProductsViewModel() { Products = products, TotalProductCount = totalProductCount });
        }
    }
}
