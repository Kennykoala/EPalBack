using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Web;

namespace isRock.Template
{
    public class LineLUISWebHookController : isRock.LineBot.LineWebHookControllerBase
    {
        const string key = "e4781b057cf44f89b83a72c196011d1c";
        const string endpoint = "epal.cognitiveservices.azure.com";
        const string appId = "bbfb9e51-a361-40e1-b1cb-7c290ba47242";

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
                        responseMsg += $"\n entities: {item.entity}({item.score}) ";
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