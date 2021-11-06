using EPalBack.Services;
using EPalBack.ViewModels.APIBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPalBack.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;
        private readonly DashBoardService _dashboardService;

        public OrderController(OrderService orderService, DashBoardService dashBoardService)
        {
            _orderService = orderService;
            _dashboardService = dashBoardService;
        }

        [HttpGet]
        public ApiResponse GetAllOrder()
        {
            try
            {
                var result = _orderService.GetAllOrder();
                return new ApiResponse(APIStatus.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse(APIStatus.Fail, ex.Message, null);
            }
        }


        [HttpGet]
        public ApiResponse GetUpaidOrder()
        {
            try
            {
                var result = _orderService.GetUpaidOrder();
                return new ApiResponse(APIStatus.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse(APIStatus.Fail, ex.Message, null);
            }
        }
        [HttpGet]
        public ApiResponse GetalreadyOrder()
        {
            try
            {
                var result = _orderService.GetalreadyOrder();
                return new ApiResponse(APIStatus.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse(APIStatus.Fail, ex.Message, null);
            }
        }

      
   


    }
}
