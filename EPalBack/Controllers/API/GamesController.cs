using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPalBack.Services;
using EPalBack.ViewModels.APIBase;
using EPalBack.ViewModels;

namespace EPalBack.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly GamesService _gamesService;
        public GamesController(GamesService gamesService)
        {
            _gamesService = gamesService;
        }

        [HttpGet]
        public ApiResponse GetGames()
        {
            try
            {
                var result = _gamesService.GetGamesInfo();
                return new ApiResponse(APIStatus.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse(APIStatus.Fail, ex.Message, null);
            }
        }



    }

}
