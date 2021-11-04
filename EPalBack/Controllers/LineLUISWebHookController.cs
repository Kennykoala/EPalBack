using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Web;
using EPalBack.Services;
using EPalBack.ViewModels;
using EPalBack.Repositories;
using EPalBack.DataModels;

namespace isRock.Template
{
    public class LineLUISWebHookController : isRock.LineBot.LineWebHookControllerBase
    {
        const string key = "e4781b057cf44f89b83a72c196011d1c";
        const string endpoint = "epal.cognitiveservices.azure.com";
        const string appId = "bbfb9e51-a361-40e1-b1cb-7c290ba47242";

        //private readonly ProductService _productService;
        private readonly LineProductService _lineproductService;
        public LineLUISWebHookController(LineProductService lineproductService)
        {
            //_productService = productService;
            _lineproductService = lineproductService;
        }

        [Route("api/LineLUIS")]
        [HttpPost]
        public IActionResult POST()
        {
            var AdminUserId = "Udf5b02c1a525f3f0881a5e8fb1a883ec";

            try
            {
                //設定ChannelAccessToken
                this.ChannelAccessToken = "sulLD9jJWPJW3RWQJVhuwL7vqcTOE6wtQCr6NND1ynH8YmUYVe9m4vFKk6OL7vMXDFbuzbN2QG47fPXGEi+g5JXt4H2eDdAEr9hCFnJqAwJDfVlgSHVPYUSGaxokiD36hV1n2BGzpcbPDJkrqMlAVgdB04t89/1O/w1cDnyilFU=";
                //配合Line Verify
                if (ReceivedMessage.events == null || ReceivedMessage.events.Count() <= 0 ||
                    ReceivedMessage.events.FirstOrDefault().replyToken == "00000000000000000000000000000000") return Ok();
                //取得Line Event
                var LineEvent = this.ReceivedMessage.events.FirstOrDefault();
                var responseMsg = "";

                //準備回覆訊息
                if (LineEvent.type.ToLower() == "message" && LineEvent.message.type == "text")
                {
                    var ret = MakeRequest(LineEvent.message.text);
                    responseMsg = $"你說了: {LineEvent.message.text}";
                    responseMsg += $"\ntopScoringIntent: {ret.topScoringIntent.intent} ";

                    //抓intent
                    foreach (var item in ret.intents)
                    {
                        responseMsg += $"\n intent: {item.intent}({item.score}) ";
                    }
                    //抓取entity
                    foreach (var item in ret.entities)
                    {
                        //if (item.type == "遊戲種類")
                        //{
                        //    string test = GetResult(item.entity);
                        //}
                        responseMsg += GetResult(item);
                        //responseMsg += $"\n entities: {item.entity}({item.score}) ";
                    }

                }
                else if (LineEvent.type.ToLower() == "message")
                    responseMsg = $"收到 event : {LineEvent.type} type: {LineEvent.message.type} ";
                else
                    responseMsg = $"收到 event : {LineEvent.type} ";

                //回覆訊息
                this.ReplyMessage(LineEvent.replyToken, responseMsg);
                //response OK
                return Ok();
            }
            catch (Exception ex)
            {
                //回覆訊息
                this.PushMessage(AdminUserId, "發生錯誤:\n" + ex.Message);
                //response OK
                return Ok();
            }
        }


        public string GetResult(Entity item)
        {
            string Default = "很抱歉,無法解析你所問的問題";
            if (item == null)
            {
                return Default;
            }

            //var intent = analysisResult.topScoringIntent;
            //var enitiesDictinary = analysisResult.Entities;
            //IList<Microsoft.Cognitive.LUIS.Entity> entitiesCollection;
            try
            {
                var result = _lineproductService.GetAllProduct();
                if(item.type == "遊戲種類")
                {
                    var bycat = result.Where(x => x.GameName == item.entity).Select(x => new LineProductViewModel()
                    {
                        ProductId = x.ProductId,
                        UnitPrice = x.UnitPrice,
                        MemberName = x.MemberName,
                        GameName = x.GameName,
                        Server = x.Server, 
                        Level = x.Level,
                        Position = x.Position,
                    }).FirstOrDefault();

                    return string.Format("遊戲種類名稱:{0} 陪玩者:{1} 單價:{2} {3}",
                        bycat.GameName,
                        bycat.MemberName,
                        bycat.UnitPrice,
                        Environment.NewLine);

                }
                //else if()
                //{

                //}
                return Default;


                ////TODO 要用設計模式比較好
                //if (intent.Name == "匯率查詢")
                //{
                //    string CurName;
                //    DateTime ExDate;
                //    if (enitiesDictinary.TryGetValue("Currency", out entitiesCollection))
                //    {
                //        CurName = entitiesCollection.Select(o => o.Value).FirstOrDefault();
                //    }
                //    else
                //    {
                //        return Default;
                //    }
                //    if (enitiesDictinary.TryGetValue("ExDate", out entitiesCollection))
                //    {
                //        DateTime.TryParse(entitiesCollection.Select(o => o.Value).FirstOrDefault(), out ExDate);
                //    }
                //    else
                //    {
                //        ExDate = DateTime.Today;
                //    }
                //    return GetCurrencyExRate(CurName, ExDate);
                //}
                //else
                //{
                //    return Default;
                //}
            }
            catch (Exception ex)
            {
                return Default;
            }
        }







        //public class ApiFilterService
        //{
        //    private readonly Repository _repo;

        //    public ApiFilterService()
        //    {
        //        _repo = new Repository();
        //    }

        //    public string GetProductCardsByFilter(FilterItemViewModel FilterVM)
        //    {
        //        var result = new ProductViewModel()
        //        {
        //            ProductCards = new List<ProductCard>()
        //        };

        //        var server = FilterVM.Server;
        //        var language = FilterVM.Language;
        //        var level = FilterVM.Level;
        //        var highAge = FilterVM.HighAge;
        //        var lowAge = FilterVM.LowAge;
        //        var highPrice = FilterVM.HighPrice;
        //        var lowPrice = FilterVM.LowPrice;
        //        var gender = FilterVM.Gender;
        //        var status = FilterVM.Status;
        //        var categoryId = FilterVM.CategoryId;

        //        var category = _repo.GetAll<GameCategories>().FirstOrDefault(x => x.GameCategoryId == categoryId);
        //        var ProductPositions = _repo.GetAll<ProductPosition>();
        //        var Positions = _repo.GetAll<Position>();
        //        var ProductServers = _repo.GetAll<ProductServer>();
        //        var thisYear = DateTime.Now.Year;

        //        if (category == null)
        //        {
        //            return result.ToString();
        //        }
        //        var products = _repo.GetAll<Products>().Where(x => x.GameCategoryId == category.GameCategoryId);

        //        if (!string.IsNullOrEmpty(status))
        //        {
        //            products = products.Where(x => x.Members.LineStatus.LineStatusName == status);
        //        }

        //        if (server != null && server.Count > 0)
        //        {
        //            ProductServers = ProductServers.Where(x => server.Contains(x.Server.ServerName));
        //            var temp = ProductServers.Select(x => x.Products).Distinct();
        //            products = products.Intersect(temp);
        //        }

        //        if (language != null && language.Count > 0)
        //        {
        //            products = products.Where(x => language.Contains(x.Members.Language.LanguageName));
        //        }

        //        if (level != null && level.Count > 0)
        //        {
        //            products = products.Where(x => level.Contains(x.Rank.RankName));
        //        }

        //        if (!string.IsNullOrEmpty(lowAge))
        //        {
        //            int lowage = thisYear - int.Parse(lowAge);
        //            products = products.Where(x => x.Members.BirthDay.Value.Year <= lowage);
        //        }

        //        if (!string.IsNullOrEmpty(highAge))
        //        {
        //            int highage = thisYear - int.Parse(highAge);
        //            products = products.Where(x => x.Members.BirthDay.Value.Year >= highage);
        //        }

        //        if (!string.IsNullOrEmpty(lowPrice))
        //        {
        //            decimal lowprice = decimal.Parse(lowPrice);
        //            products = products.Where(x => x.UnitPrice >= lowprice);
        //        }

        //        if (!string.IsNullOrEmpty(highPrice))
        //        {
        //            decimal highprice = decimal.Parse(highPrice);
        //            products = products.Where(x => x.UnitPrice <= highprice);
        //        }
        //        if (!string.IsNullOrEmpty(gender))
        //        {
        //            if (gender == "Male")
        //            {
        //                products = products.Where(x => x.Members.Gender == 1);
        //            }
        //            if (gender == "Female")
        //            {
        //                products = products.Where(x => x.Members.Gender == 0);
        //            }
        //            else
        //            {
        //                products = products.Select(x => x);
        //            }
        //        }
        //        var productCards = products.Select(p => new ProductCard
        //        {
        //            UnitPrice = p.UnitPrice,
        //            CreatorImg = p.CreatorImg,
        //            Introduction = p.Introduction,
        //            RecommendationVoice = p.RecommendationVoice,
        //            LineStatus = p.Members.LineStatus.LineStatusImg,
        //            CreatorName = p.Members.MemberName,
        //            Rank = p.Rank.RankName,
        //            ProductId = p.ProductId,
        //            Position = Positions.FirstOrDefault(y => y.PositionId == (ProductPositions.FirstOrDefault(x => x.ProductId == p.ProductId).PositionId)).PositionName,
        //        }).ToList();
        //        result.ProductCards = productCards;
        //        result.CategoryId = categoryId;

        //        return JsonConvert.SerializeObject(result);
        //    }
        //}















        static LUISResult MakeRequest(string utterance)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            var endpointUri = String.Format(
                "https://{0}/luis/v2.0/apps/{1}?verbose=true&timezoneOffset=0&subscription-key={3}&q={2}",
                endpoint, appId, utterance, key);

            var response = client.GetAsync(endpointUri).Result;

            var strResponseContent = response.Content.ReadAsStringAsync().Result;
            var Result = Newtonsoft.Json.JsonConvert.DeserializeObject<LUISResult>(strResponseContent);
            // Display the JSON result from LUIS
            return Result;
        }
    }




    //const string key = "e4781b057cf44f89b83a72c196011d1c";
    //const string endpoint = "epal.cognitiveservices.azure.com";
    //const string appId = "bbfb9e51-a361-40e1-b1cb-7c290ba47242";

    //[Route("api/LineLUIS")]
    //[HttpPost]
    //public IActionResult POST()
    //{
    //    var AdminUserId = "Udf5b02c1a525f3f0881a5e8fb1a883ec";

    //    try
    //    {
    //        //設定ChannelAccessToken
    //        this.ChannelAccessToken = "sulLD9jJWPJW3RWQJVhuwL7vqcTOE6wtQCr6NND1ynH8YmUYVe9m4vFKk6OL7vMXDFbuzbN2QG47fPXGEi+g5JXt4H2eDdAEr9hCFnJqAwJDfVlgSHVPYUSGaxokiD36hV1n2BGzpcbPDJkrqMlAVgdB04t89/1O/w1cDnyilFU=";
    //        //配合Line Verify
    //        if (ReceivedMessage.events == null || ReceivedMessage.events.Count() <= 0 ||
    //            ReceivedMessage.events.FirstOrDefault().replyToken == "00000000000000000000000000000000") return Ok();
    //        //取得Line Event
    //        var LineEvent = this.ReceivedMessage.events.FirstOrDefault();
    //        var responseMsg = "";

    //        //準備回覆訊息
    //        if (LineEvent.type.ToLower() == "message" && LineEvent.message.type == "text")
    //        {
    //            var ret = MakeRequest(LineEvent.message.text);
    //            responseMsg = $"你說了: {LineEvent.message.text}";
    //            responseMsg += $"\ntopScoringIntent: {ret.topScoringIntent.intent} ";

    //            //抓intent
    //            foreach (var item in ret.intents)
    //            {
    //                responseMsg += $"\n intent: {item.intent}({item.score}) ";
    //            }
    //            //抓取entity
    //            foreach (var item in ret.entities)
    //            {
    //                responseMsg += $"\n entities: {item.entity}({item.score}) ";
    //            }

    //        }
    //        else if (LineEvent.type.ToLower() == "message")
    //            responseMsg = $"收到 event : {LineEvent.type} type: {LineEvent.message.type} ";
    //        else
    //            responseMsg = $"收到 event : {LineEvent.type} ";

    //        //回覆訊息
    //        this.ReplyMessage(LineEvent.replyToken, responseMsg);
    //        //response OK
    //        return Ok();
    //    }
    //    catch (Exception ex)
    //    {
    //        //回覆訊息
    //        this.PushMessage(AdminUserId, "發生錯誤:\n" + ex.Message);
    //        //response OK
    //        return Ok();
    //    }
    //}






    #region "LUIS Model"

    public class TopScoringIntent
    {
        public string intent { get; set; }
        public double score { get; set; }
    }

    public class Intent
    {
        public string intent { get; set; }
        public double score { get; set; }
    }

    public class Resolution
    {
        public string value { get; set; }
    }

    public class Entity
    {
        public string entity { get; set; }
        public string type { get; set; }
        public int startIndex { get; set; }
        public int endIndex { get; set; }
        public double score { get; set; }
        public Resolution resolution { get; set; }
    }

    public class LUISResult
    {
        public string query { get; set; }
        public TopScoringIntent topScoringIntent { get; set; }
        public List<Intent> intents { get; set; }
        public List<Entity> entities { get; set; }
    }
    #endregion
}