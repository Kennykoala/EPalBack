using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPalBack.Services;
using EPalBack.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace isRock.Template
{
    public class LineWebHookController : isRock.LineBot.LineWebHookControllerBase
    {

        private readonly ProductService _productService;
        public LineWebHookController()
        {
            _productService = new ProductService();
        }


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
                //if (LineEvent.type.ToLower() == "message" && LineEvent.message.type.ToLower() == "text" && LineEvent.message.text == "請選擇遊戲種類")
                if (LineEvent.message.text == "請選擇遊戲種類")
                {
                    //responseMsg = $"hi{user.displayName},你說了{LineEvent.message.text}";

                    isRock.LineBot.TextMessage msg = new isRock.LineBot.TextMessage("EPal Game Categories");

                    msg.quickReply.items.Add(
                        new isRock.LineBot.QuickReplyMessageAction(
                            "League of Legends", "League of Legends", new Uri("https://arock.blob.core.windows.net/blogdata201809/if_resolutions-25_897228.png")));
                    msg.quickReply.items.Add(
                        new isRock.LineBot.QuickReplyMessageAction(
                            "E-Chat", "E-Chat", new Uri("https://arock.blob.core.windows.net/blogdata201809/if_busy_83242.png")));
                    msg.quickReply.items.Add(
                        new isRock.LineBot.QuickReplyMessageAction(
                            "Movie", "Movie", new Uri("https://arock.blob.core.windows.net/blogdata201809/if_emoji_emoticon-35_3638429.png")));
                    msg.quickReply.items.Add(
                        new isRock.LineBot.QuickReplyMessageAction(
                            "Valorant", "Valorant", new Uri("https://arock.blob.core.windows.net/blogdata201809/if_emoji_emoticon-35_3638429.png")));
                    msg.quickReply.items.Add(
                        new isRock.LineBot.QuickReplyMessageAction(
                            "Custom Game", "Custom Game", new Uri("https://arock.blob.core.windows.net/blogdata201809/if_emoji_emoticon-35_3638429.png")));
                    msg.quickReply.items.Add(
                        new isRock.LineBot.QuickReplyMessageAction(
                            "Minecraft", "Minecraft", new Uri("https://arock.blob.core.windows.net/blogdata201809/if_emoji_emoticon-35_3638429.png")));
                    msg.quickReply.items.Add(
                        new isRock.LineBot.QuickReplyMessageAction(
                            "Among Us", "Among Us", new Uri("https://arock.blob.core.windows.net/blogdata201809/if_emoji_emoticon-35_3638429.png")));
                    msg.quickReply.items.Add(
                        new isRock.LineBot.QuickReplyMessageAction(
                            "Apex Legends", "Apex Legends", new Uri("https://arock.blob.core.windows.net/blogdata201809/if_emoji_emoticon-35_3638429.png")));
                    msg.quickReply.items.Add(
                        new isRock.LineBot.QuickReplyMessageAction(
                            "Teamfight Tactics", "Teamfight Tactics", new Uri("https://arock.blob.core.windows.net/blogdata201809/if_emoji_emoticon-35_3638429.png")));
                    msg.quickReply.items.Add(
                        new isRock.LineBot.QuickReplyMessageAction(
                            "Overwatch", "Overwatch", new Uri("https://arock.blob.core.windows.net/blogdata201809/if_emoji_emoticon-35_3638429.png")));
                    msg.quickReply.items.Add(
                        new isRock.LineBot.QuickReplyMessageAction(
                            "Sleep Call", "Sleep Call", new Uri("https://arock.blob.core.windows.net/blogdata201809/if_emoji_emoticon-35_3638429.png")));
                    //msg.quickReply.items.Add(
                    //    new isRock.LineBot.QuickReplyMessageAction(
                    //        "Animal Crossing: New Horizons", "Animal Crossing: New Horizons", new Uri("https://arock.blob.core.windows.net/blogdata201809/if_emoji_emoticon-35_3638429.png")));
                    //msg.quickReply.items.Add(
                    //    new isRock.LineBot.QuickReplyMessageAction(
                    //        "Others", "Others", new Uri("https://arock.blob.core.windows.net/blogdata201809/if_emoji_emoticon-35_3638429.png")));


                    isRock.LineBot.Bot bot = new isRock.LineBot.Bot(ChannelAccessToken);
                    bot.PushMessage(AdminUserId, msg);
                    return Ok();

                }
                else if(LineEvent.type.ToLower() == "message" && LineEvent.message.type.ToLower() == "text")
                {
                    //responseMsg = $"hi{user.displayName},你說了{LineEvent.message.text}";

                    //responseMsg += GetResult(LineEvent.message.text);
                    bool reply = GetResult(LineEvent.message.text, LineEvent.replyToken, AdminUserId);
                    return Ok();

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
                {
                    responseMsg = $"收到 event : {LineEvent.type} ";
                }

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




        public bool GetResult(string keyword, string token, string AdminUserId)
        {
            string Default = "很抱歉，關鍵字有誤";
            if (keyword == null)
            {
                return false;
                //return Default;
            }

            //var intent = analysisResult.topScoringIntent;
            //var enitiesDictinary = analysisResult.Entities;
            //IList<Microsoft.Cognitive.LUIS.Entity> entitiesCollection;
            try
            {
                var result = _productService.GetAllProduct();
                //判斷遊戲種類
                bool gamename = result.Any(x => x.GameName == keyword);
                var rnd = new Random();
                string replymsg = "";
                if (gamename)
                {
                    var bycat = result.Where(x => x.GameName == keyword).Select(x => new ProductViewModel()
                                        {
                                            ProductId = x.ProductId,
                                            UnitPrice = x.UnitPrice,
                                            MemberName = x.MemberName,
                                            GameName = x.GameName,
                                            Server = x.Server,
                                            Level = x.Level,
                                            Position = x.Position,
                                        })
                                        .OrderBy(x => rnd.Next()).Take(3);

                    replymsg += string.Concat($"遊戲種類名稱:{keyword}", Environment.NewLine);
                    foreach (var cat in bycat)
                    {
                        replymsg += string.Format("商品序號:{0} 陪玩者:{1} 單價:${2} {3}",
                            cat.ProductId,
                            cat.MemberName,
                            cat.UnitPrice,
                            Environment.NewLine);

                    }
                    //return replymsg;



                }
                ////else if()
                ////{

                ////}
                //Default = "找不到相關商品";
                //return Default;


            }
            catch (Exception ex)
            {
                return false;
                //return Default;
            }


            //建立actions，作為ButtonTemplate的用戶回覆行為
            var actions = new List<isRock.LineBot.TemplateActionBase>();
            actions.Add(new isRock.LineBot.MessageAction() { label = "標題-文字回覆", text = "回覆文字" });
            actions.Add(new isRock.LineBot.UriAction() { label = "標題-Google", uri = new Uri("http://www.google.com") });
            actions.Add(new isRock.LineBot.PostbackAction() { label = "標題-發生postack", data = "abc=aaa&def=111" });

            //單一Column 
            var Column = new isRock.LineBot.Column
            {
                text = "ButtonsTemplate文字訊息",
                title = "ButtonsTemplate標題",
                //設定圖片
                thumbnailImageUrl = new Uri("https://arock.blob.core.windows.net/blogdata201709/14-143030-1cd8cf1e-8f77-4652-9afa-605d27f20933.png"),
                actions = actions //設定回覆動作
            };

            //建立CarouselTemplate
            var CarouselTemplate = new isRock.LineBot.CarouselTemplate();

            //這是範例，所以用一組樣板建立三個
            CarouselTemplate.columns.Add(Column);
            CarouselTemplate.columns.Add(Column);
            CarouselTemplate.columns.Add(Column);

            ////建立bot instance
            //isRock.LineBot.Bot bot = new isRock.LineBot.Bot(token);

            ////發送 CarouselTemplate
            //bot.PushMessage(AdminUserId, CarouselTemplate);
            //return true;

            //回覆訊息
            ReplyMessage(token, CarouselTemplate);
            //response OK
            return true;


        }










        //[Route("api/LineBotWebHook")]
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

        //        //抓當前與linebot對話的usedid
        //        var user = this.GetUserInfo(LineEvent.source.userId);

        //        //準備回覆訊息
        //        if (LineEvent.type.ToLower() == "message" && LineEvent.message.type.ToLower() == "text")
        //        {
        //            responseMsg = $"hi{user.displayName},你說了{LineEvent.message.text}";
        //        }
        //        else if (LineEvent.type.ToLower() == "message" && LineEvent.message.type.ToLower() == "sticker")
        //        {
        //            this.ReplyMessage(LineEvent.replyToken, 1, 2);
        //            return Ok();
        //        }
        //        else if (LineEvent.type.ToLower() == "message")
        //        {
        //            responseMsg = $"收到 event : {LineEvent.type} type: {LineEvent.message.type} ";
        //        }
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

    }
}