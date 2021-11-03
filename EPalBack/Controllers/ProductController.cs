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
        private readonly DashBoardService _dashboardService;

        public ProductController(ProductService productService,DashBoardService dashBoardService)
        {
            _productService = productService;
            _dashboardService = dashBoardService;
        }

        [HttpGet]
        public ApiResponse GetAllProduct()
        {
            try
            {
                var result = _productService.GetAllProduct();
                return new ApiResponse(APIStatus.Success, string.Empty, result);
            }
            catch(Exception ex)
            {
                return new ApiResponse(APIStatus.Fail, ex.Message, null);
            }
        }

        [HttpGet("{id:int}")]
        public ApiResponse GetProductDetails(int id)
        {
            try
            {
                var result = _productService.GetProductDetails(id);
                return new ApiResponse(APIStatus.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse(APIStatus.Fail, ex.Message, null);
            }
        }

        [HttpGet]
        public ApiResponse GetAllCount()
        {
            try
            {
                var result = _dashboardService.GetAllCount();
                return new ApiResponse(APIStatus.Success, string.Empty, result);
            }
            catch(Exception ex)
            {
                return new ApiResponse(APIStatus.Fail, ex.Message, null);
            }
        }

        [HttpGet]
        public ApiResponse GetAllServer()
        {
            try
            {
                var result = _productService.GetAllServer();
                return new ApiResponse(APIStatus.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse(APIStatus.Fail, ex.Message, null);
            }
        }

        [HttpGet]
        public ApiResponse GetAllLanguage()
        {
            try
            {
                var result = _productService.GetAllLanguage();
                return new ApiResponse(APIStatus.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse(APIStatus.Fail, ex.Message, null);
            }
        }

        [HttpGet]
        public ApiResponse GetAllStyle()
        {
            try
            {
                var result = _productService.GetAllStyle();
                return new ApiResponse(APIStatus.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse(APIStatus.Fail, ex.Message, null);
            }
        }

        [HttpGet]
        public ApiResponse GetAllGame()
        {
            try
            {
                var result = _productService.GetAllGame();
                return new ApiResponse(APIStatus.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse(APIStatus.Fail, ex.Message, null);
            }
        }

        [HttpPost]
        public ApiResponse DeleteProduct(ProductDetailsViewModel request)
        {
            try
            {
                _productService.DeleteProduct(request);
                return new ApiResponse(APIStatus.Success, string.Empty, true);
            }
            catch (Exception ex)
            {
                return new ApiResponse(APIStatus.Fail, ex.Message, false);
            }
        }

        [HttpPost]
        public ApiResponse UpdateProduct(ProductDetailsViewModel request)
        {
            try
            {
                _productService.UpdateProduct(request);
                return new ApiResponse(APIStatus.Success, string.Empty, true);
            }
            catch (Exception ex)
            {
                return new ApiResponse(APIStatus.Fail, ex.Message, false);
            }
        }
    }
}
