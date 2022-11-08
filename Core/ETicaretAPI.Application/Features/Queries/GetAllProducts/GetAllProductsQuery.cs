using ETicaretAPI.Application.ViewModels.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.GetAllProducts
{
    public class GetAllProductsQuery:IRequest<GetAllProductsViewModel>
    {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 5;
    }
}
