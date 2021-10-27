using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPalBack.Services;
using EPalBack.ViewModels.APIBase;
using EPalBack.ViewModels;

namespace EPalBack.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController()
        {
            _productService = new ProductService();
        }

        [HttpGet]
        public ApiResonse GetAllProduct()
        {
            try
            {
                var result = _productService.GetAllProduct();
                return new ApiResonse(APIStatus.Success, string.Empty, result);
            }
            catch(Exception ex)
            {
                return new ApiResonse(APIStatus.Fail, ex.Message, null);
            }
        }

        [HttpPost]
        public ApiResonse DeleteProduct(ProductViewModel request)
        {
            try
            {
                _productService.DeleteProduct(request);
                return new ApiResonse(APIStatus.Success, string.Empty, true);
            }
            catch (Exception ex)
            {
                return new ApiResonse(APIStatus.Fail, ex.Message, false);
            }
        }

        [HttpPost]
        public ApiResonse UpdatePokemon(ProductViewModel request)
        {
            try
            {
                _productService.UpdateProduct(request);
                return new ApiResonse(APIStatus.Success, string.Empty, true);
            }
            catch (Exception ex)
            {
                return new ApiResonse(APIStatus.Fail, ex.Message, false);
            }
        }
    }
}
