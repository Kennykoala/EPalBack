using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace isRock.Template
{
    public class LineWebHookController : isRock.LineBot.LineWebHookControllerBase
    {
        [Route("api/LineBotWebHook")]
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

                //抓當前與linebot對話的usedid
                var user = this.GetUserInfo(LineEvent.source.userId);

                //準備回覆訊息
                if (LineEvent.type.ToLower() == "message" && LineEvent.message.type.ToLower() == "text")
                {
                    responseMsg = $"hi{user.displayName},你說了{LineEvent.message.text}";
                }
                else if (LineEvent.type.ToLower() == "message" && LineEvent.message.type.ToLower() == "sticker")
                {
                    this.ReplyMessage(LineEvent.replyToken, 1, 2);
                    return Ok();
                }
                else if (LineEvent.type.ToLower() == "message")
                {
                    responseMsg = $"收到 event : {LineEvent.type} type: {LineEvent.message.type} ";
                }
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
    }
}