using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.ViewModels.Products
{
    public class GetAllProductsViewModel
    {
        public int TotalProductCount { get; set; }
        public List<GetProductViewModel> Products { get; set; }
    }
}
