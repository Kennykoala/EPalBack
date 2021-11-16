using EPalBack.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPalBack.Services.Interface
{
    interface IProductService
    {
        List<ProductViewModel> GetAll();
        IEnumerable<ProductViewModel> GetMostPopular(int topMax);
        List<ProductViewModel> GetRecommend(int topMax);
    }
}
