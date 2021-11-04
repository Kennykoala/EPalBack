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

        //private readonly ProductService _productService;
        private readonly LineProductService _lineproductService;
        public LineWebHookController(LineProductService lineproductService)
        {
            //_productService = productService;
            _lineproductService = lineproductService;
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
                if (LineEvent.message.text == "請選擇遊戲種類")
                {
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
                else if (LineEvent.message.text == "請選擇陪玩師性別")
                {
                    isRock.LineBot.TextMessage msg = new isRock.LineBot.TextMessage("EPal Creator Gender");

                    msg.quickReply.items.Add(
                        new isRock.LineBot.QuickReplyMessageAction(
                            "Male", "Male", new Uri("https://arock.blob.core.windows.net/blogdata201809/if_resolutions-25_897228.png")));
                    msg.quickReply.items.Add(
                        new isRock.LineBot.QuickReplyMessageAction(
                            "Female", "Female", new Uri("https://arock.blob.core.windows.net/blogdata201809/if_busy_83242.png")));

                    isRock.LineBot.Bot bot = new isRock.LineBot.Bot(ChannelAccessToken);
                    bot.PushMessage(AdminUserId, msg);
                    return Ok();

                }
                else if (LineEvent.message.text == "請選擇陪玩師等級")
                {
                    isRock.LineBot.TextMessage msg = new isRock.LineBot.TextMessage("EPal Creator Level");

                    msg.quickReply.items.Add(
                        new isRock.LineBot.QuickReplyMessageAction(
                            "Iron", "Iron", new Uri("https://arock.blob.core.windows.net/blogdata201809/if_resolutions-25_897228.png")));
                    msg.quickReply.items.Add(
                        new isRock.LineBot.QuickReplyMessageAction(
                            "Bronze", "Bronze", new Uri("https://arock.blob.core.windows.net/blogdata201809/if_busy_83242.png")));
                    msg.quickReply.items.Add(
                        new isRock.LineBot.QuickReplyMessageAction(
                            "Silver", "Silver", new Uri("https://arock.blob.core.windows.net/blogdata201809/if_busy_83242.png")));
                    msg.quickReply.items.Add(
                        new isRock.LineBot.QuickReplyMessageAction(
                            "Gold", "Gold", new Uri("https://arock.blob.core.windows.net/blogdata201809/if_busy_83242.png")));
                    msg.quickReply.items.Add(
                        new isRock.LineBot.QuickReplyMessageAction(
                            "Platinum", "Platinum", new Uri("https://arock.blob.core.windows.net/blogdata201809/if_busy_83242.png")));
                    msg.quickReply.items.Add(
                        new isRock.LineBot.QuickReplyMessageAction(
                            "Diamond", "Diamond", new Uri("https://arock.blob.core.windows.net/blogdata201809/if_busy_83242.png")));

                    isRock.LineBot.Bot bot = new isRock.LineBot.Bot(ChannelAccessToken);
                    bot.PushMessage(AdminUserId, msg);
                    return Ok();

                }
                else if (LineEvent.message.text == "請選擇遊戲產品價格")
                {
                    isRock.LineBot.TextMessage msg = new isRock.LineBot.TextMessage("EPal Game Unitprice");

                    msg.quickReply.items.Add(
                        new isRock.LineBot.QuickReplyMessageAction(
                            "$1~$5", "$1~$5", new Uri("https://arock.blob.core.windows.net/blogdata201809/if_resolutions-25_897228.png")));
                    msg.quickReply.items.Add(
                        new isRock.LineBot.QuickReplyMessageAction(
                            "$5~$10", "$5~$10", new Uri("https://arock.blob.core.windows.net/blogdata201809/if_busy_83242.png")));
                    msg.quickReply.items.Add(
                        new isRock.LineBot.QuickReplyMessageAction(
                            "$10~$20", "$10~$20", new Uri("https://arock.blob.core.windows.net/blogdata201809/if_busy_83242.png")));
                    msg.quickReply.items.Add(
                        new isRock.LineBot.QuickReplyMessageAction(
                            "$20 up", "$20 up", new Uri("https://arock.blob.core.windows.net/blogdata201809/if_busy_83242.png")));

                    isRock.LineBot.Bot bot = new isRock.LineBot.Bot(ChannelAccessToken);
                    bot.PushMessage(AdminUserId, msg);
                    return Ok();

                }
                else if (LineEvent.message.text == "請選擇遊戲伺服器")
                {
                    isRock.LineBot.TextMessage msg = new isRock.LineBot.TextMessage("EPal Game Server");

                    msg.quickReply.items.Add(
                        new isRock.LineBot.QuickReplyMessageAction(
                            "OCE", "OCE", new Uri("https://arock.blob.core.windows.net/blogdata201809/if_resolutions-25_897228.png")));
                    msg.quickReply.items.Add(
                        new isRock.LineBot.QuickReplyMessageAction(
                            "NA", "NA", new Uri("https://arock.blob.core.windows.net/blogdata201809/if_busy_83242.png")));
                    msg.quickReply.items.Add(
                        new isRock.LineBot.QuickReplyMessageAction(
                            "LAN", "LAN", new Uri("https://arock.blob.core.windows.net/blogdata201809/if_busy_83242.png")));
                    msg.quickReply.items.Add(
                        new isRock.LineBot.QuickReplyMessageAction(
                            "BR", "BR", new Uri("https://arock.blob.core.windows.net/blogdata201809/if_busy_83242.png")));
                    msg.quickReply.items.Add(
                        new isRock.LineBot.QuickReplyMessageAction(
                            "EU West", "EU West", new Uri("https://arock.blob.core.windows.net/blogdata201809/if_busy_83242.png")));
                    msg.quickReply.items.Add(
                        new isRock.LineBot.QuickReplyMessageAction(
                            "EU NorthEast", "EU NorthEast", new Uri("https://arock.blob.core.windows.net/blogdata201809/if_busy_83242.png")));

                    isRock.LineBot.Bot bot = new isRock.LineBot.Bot(ChannelAccessToken);
                    bot.PushMessage(AdminUserId, msg);
                    return Ok();

                }
                else if(LineEvent.type.ToLower() == "message" && LineEvent.message.type.ToLower() == "text")
                {
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
            //string Default = "很抱歉，關鍵字有誤";
            if (keyword == null)
            {
                return false;
                //return Default;
            }


            //CarouselTemplate
            var CarouselTemplate = new isRock.LineBot.CarouselTemplate();

            int gendernum = keyword == "Male" ? 0 : 1;
            try
            {
                var result = _lineproductService.GetAllProduct();
                
                //判斷遊戲種類
                bool gamename = result.Any(x => x.GameName == keyword);
                //判斷性別
                bool gender = result.Any(x => x.gender == gendernum);
                //判斷陪玩師等級
                bool level = result.Any(x => x.Level == keyword);
                //判斷遊戲伺服器
                bool server = result.Any(x => x.Server == keyword);
                //判斷遊戲產品價格
                bool productprice;
                switch (keyword)
                {
                    case "$1~$5":
                        productprice = result.Any(x => x.UnitPrice >= 1M && x.UnitPrice <= 5M);
                        break;
                    case "$5~$10":
                        productprice = result.Any(x => x.UnitPrice >= 5M && x.UnitPrice <= 10M);
                        break;
                    case "$10~$20":
                        productprice = result.Any(x => x.UnitPrice >= 10M && x.UnitPrice <= 20M);
                        break;
                    case "$20 up":
                        productprice = result.Any(x => x.UnitPrice >= 20M);
                        break;
                    default:
                        productprice = false;
                        break;
                }              
                

                var rnd = new Random();
                //string replymsg = "";

                if (gamename)
                {
                    var bycat = result.Where(x => x.GameName == keyword).Select(x => new LineProductViewModel()
                                        {
                                            ProductId = x.ProductId,
                                            UnitPrice = x.UnitPrice,
                                            MemberName = x.MemberName,
                                            GameName = x.GameName,
                                            Server = x.Server,
                                            Level = x.Level,
                                            Position = x.Position,
                                            CreatorImg = x.CreatorImg
                                        })
                                        .OrderBy(x => rnd.Next()).Take(5);

                    foreach (var cat in bycat)
                    {
                        var creatorimg = cat.CreatorImg;
                        var memberName = cat.MemberName;
                        var price = cat.UnitPrice.ToString();
                        var proId = cat.ProductId;

                        var prourl = string.Format("https://epal-frontstage.azurewebsites.net/ePals/Detail/{0}",
                            proId);

                        var carouseltext = string.Format("{0} {1}${2}",
                                    cat.MemberName,
                                    Environment.NewLine,
                                    cat.UnitPrice);

                        var actions = new List<isRock.LineBot.TemplateActionBase>();
                        actions.Add(new isRock.LineBot.UriAction() { label = "Go To Detail Page", uri = new Uri(prourl) });

                        var Column = new isRock.LineBot.Column
                        {
                            text = carouseltext,
                            title = keyword,
                            thumbnailImageUrl = new Uri(creatorimg),
                            actions = actions 
                        };

                        CarouselTemplate.columns.Add(Column);

                    }

                }
                else if (gender)
                {
                    var bycat = result.Where(x => x.gender == gendernum).Select(x => new LineProductViewModel()
                                        {
                                            ProductId = x.ProductId,
                                            UnitPrice = x.UnitPrice,
                                            MemberName = x.MemberName,
                                            GameName = x.GameName,
                                            Server = x.Server,
                                            Level = x.Level,
                                            Position = x.Position,
                                            CreatorImg = x.CreatorImg
                                        })
                                        .OrderBy(x => rnd.Next()).Take(5);

                    foreach (var cat in bycat)
                    {
                        var creatorimg = cat.CreatorImg;
                        var memberName = cat.MemberName;
                        var price = cat.UnitPrice.ToString();
                        var proId = cat.ProductId;
                        var productname = cat.GameName;

                        var prourl = string.Format("https://epal-frontstage.azurewebsites.net/ePals/Detail/{0}",
                            proId);

                        var carouseltext = string.Format("{0} {1}${2}",
                                    cat.MemberName,
                                    Environment.NewLine,
                                    cat.UnitPrice);

                        var actions = new List<isRock.LineBot.TemplateActionBase>();
                        actions.Add(new isRock.LineBot.UriAction() { label = "Go To Detail Page", uri = new Uri(prourl) });

                        var Column = new isRock.LineBot.Column
                        {
                            text = carouseltext,
                            title = productname,
                            thumbnailImageUrl = new Uri(creatorimg),
                            actions = actions
                        };
                        CarouselTemplate.columns.Add(Column);

                    }
                }
                else if (level)
                {
                    var bycat = result.Where(x => x.Level == keyword).Select(x => new LineProductViewModel()
                                        {
                                            ProductId = x.ProductId,
                                            UnitPrice = x.UnitPrice,
                                            MemberName = x.MemberName,
                                            GameName = x.GameName,
                                            Server = x.Server,
                                            Level = x.Level,
                                            Position = x.Position,
                                            CreatorImg = x.CreatorImg
                                        })
                                        .OrderBy(x => rnd.Next()).Take(5);

                    foreach (var cat in bycat)
                    {
                        var creatorimg = cat.CreatorImg;
                        var memberName = cat.MemberName;
                        var price = cat.UnitPrice.ToString();
                        var proId = cat.ProductId;
                        var productname = cat.GameName;

                        var prourl = string.Format("https://epal-frontstage.azurewebsites.net/ePals/Detail/{0}",
                            proId);

                        var carouseltext = string.Format("{0} {1}${2}",
                                    cat.MemberName,
                                    Environment.NewLine,
                                    cat.UnitPrice);

                        var actions = new List<isRock.LineBot.TemplateActionBase>();
                        actions.Add(new isRock.LineBot.UriAction() { label = "Go To Detail Page", uri = new Uri(prourl) });

                        var Column = new isRock.LineBot.Column
                        {
                            text = carouseltext,
                            title = productname,
                            thumbnailImageUrl = new Uri(creatorimg),
                            actions = actions 
                        };
                        CarouselTemplate.columns.Add(Column);

                    }
                }
                else if (productprice)
                {
                    var pricelist = new List<LineProductViewModel>();
                    //判斷遊戲產品價格
                    switch (keyword)
                    {
                        case "$1~$5":
                            pricelist = result.Where(x => x.UnitPrice >= 1M && x.UnitPrice <= 5M).ToList();
                            break;
                        case "$5~$10":
                            pricelist = result.Where(x => x.UnitPrice >= 5M && x.UnitPrice <= 10M).ToList();
                            break;
                        case "$10~$20":
                            pricelist = result.Where(x => x.UnitPrice >= 10M && x.UnitPrice <= 20M).ToList();
                            break;
                        case "$20 up":
                            pricelist = result.Where(x => x.UnitPrice >= 20M).ToList();
                            break;
                        default:
                            pricelist = null;
                            break;
                    }

                    var bycat = pricelist.Select(x => new LineProductViewModel()
                                        {
                                            ProductId = x.ProductId,
                                            UnitPrice = x.UnitPrice,
                                            MemberName = x.MemberName,
                                            GameName = x.GameName,
                                            Server = x.Server,
                                            Level = x.Level,
                                            Position = x.Position,
                                            CreatorImg = x.CreatorImg
                                        })
                                        .OrderBy(x => rnd.Next()).Take(5);

                    foreach (var cat in bycat)
                    {
                        var creatorimg = cat.CreatorImg;
                        var memberName = cat.MemberName;
                        var price = cat.UnitPrice.ToString();
                        var proId = cat.ProductId;
                        var productname = cat.GameName;

                        var prourl = string.Format("https://epal-frontstage.azurewebsites.net/ePals/Detail/{0}",
                            proId);

                        var carouseltext = string.Format("{0} {1}${2}",
                                    cat.MemberName,
                                    Environment.NewLine,
                                    cat.UnitPrice);

                        var actions = new List<isRock.LineBot.TemplateActionBase>();
                        actions.Add(new isRock.LineBot.UriAction() { label = "Go To Detail Page", uri = new Uri(prourl) });

                        var Column = new isRock.LineBot.Column
                        {
                            text = carouseltext,
                            title = productname,
                            thumbnailImageUrl = new Uri(creatorimg),
                            actions = actions
                        };
                        CarouselTemplate.columns.Add(Column);

                    }
                }
                else if (server)
                {
                    var bycat = result.Where(x => x.Server == keyword).Select(x => new LineProductViewModel()
                                            {
                                                ProductId = x.ProductId,
                                                UnitPrice = x.UnitPrice,
                                                MemberName = x.MemberName,
                                                GameName = x.GameName,
                                                Server = x.Server,
                                                Level = x.Level,
                                                Position = x.Position,
                                                CreatorImg = x.CreatorImg
                                            })
                                        .OrderBy(x => rnd.Next()).Take(5);

                    foreach (var cat in bycat)
                    {
                        var creatorimg = cat.CreatorImg;
                        var memberName = cat.MemberName;
                        var price = cat.UnitPrice.ToString();
                        var proId = cat.ProductId;
                        var productname = cat.GameName;

                        var prourl = string.Format("https://epal-frontstage.azurewebsites.net/ePals/Detail/{0}",
                            proId);

                        var carouseltext = string.Format("{0} {1}${2}",
                                    cat.MemberName,
                                    Environment.NewLine,
                                    cat.UnitPrice);

                        var actions = new List<isRock.LineBot.TemplateActionBase>();
                        actions.Add(new isRock.LineBot.UriAction() { label = "Go To Detail Page", uri = new Uri(prourl) });

                        var Column = new isRock.LineBot.Column
                        {
                            text = carouseltext,
                            title = productname,
                            thumbnailImageUrl = new Uri(creatorimg),
                            actions = actions
                        };
                        CarouselTemplate.columns.Add(Column);

                    }
                }
                //Default = "找不到相關商品";
                //return Default;


            }
            catch (Exception ex)
            {
                return false;
                //return Default;
            }


            ReplyMessage(token, CarouselTemplate);
            return true;
        }














    //                        //replymsg += string.Concat($"遊戲種類名稱:{keyword}", Environment.NewLine);
    //                foreach (var cat in bycat)
    //                {
    //                    //replymsg += string.Format("商品序號:{0} 陪玩者:{1} 單價:${2} {3}",
    //                    //    cat.ProductId,
    //                    //    cat.MemberName,
    //                    //    cat.UnitPrice,
    //                    //    cat.CreatorImg,
    //                    //    Environment.NewLine);

    //                    var creatorimg = cat.CreatorImg;
    //    var memberName = cat.MemberName;
    //    var price = cat.UnitPrice.ToString();
    //    var proId = cat.ProductId;

    //    var prourl = string.Format("https://epal-frontstage.azurewebsites.net/ePals/Detail/{0}",
    //        proId);

    //    var carouseltext = string.Format("{0} {1}${2}",
    //                cat.MemberName,
    //                Environment.NewLine,
    //                cat.UnitPrice);


    //    //建立actions，作為ButtonTemplate的用戶回覆行為
    //    var actions = new List<isRock.LineBot.TemplateActionBase>();
    //    //actions.Add(new isRock.LineBot.MessageAction() { label = "標題-文字回覆", text = "回覆文字" });
    //    actions.Add(new isRock.LineBot.UriAction() { label = "Go To Detail Page", uri = new Uri(prourl) });
    //                    //actions.Add(new isRock.LineBot.PostbackAction() { label = "標題-發生postack", data = "abc=aaa&def=111" });


    //                    //單一Column 
    //                    var Column = new isRock.LineBot.Column
    //                    {
    //                        text = carouseltext,
    //                        //keyword == gamename
    //                        title = keyword,
    //                        thumbnailImageUrl = new Uri(creatorimg),
    //                        actions = actions //設定回覆動作
    //                    };

    //CarouselTemplate.columns.Add(Column);

    //                }








    //    //建立actions，作為ButtonTemplate的用戶回覆行為
    //    var actions = new List<isRock.LineBot.TemplateActionBase>();
    //    //actions.Add(new isRock.LineBot.MessageAction() { label = "標題-文字回覆", text = "回覆文字" });
    //    actions.Add(new isRock.LineBot.UriAction() { label = "Go To EPal", uri = new Uri("http://www.google.com") });
    //        //actions.Add(new isRock.LineBot.PostbackAction() { label = "標題-發生postack", data = "abc=aaa&def=111" });

    //        //單一Column 
    //        var Column = new isRock.LineBot.Column
    //        {
    //            text = "ButtonsTemplate文字訊息",
    //            title = "ButtonsTemplate標題",
    //            //設定圖片
    //            thumbnailImageUrl = new Uri("https://arock.blob.core.windows.net/blogdata201709/14-143030-1cd8cf1e-8f77-4652-9afa-605d27f20933.png"),
    //            actions = actions //設定回覆動作
    //        };

    ////建立CarouselTemplate
    //var CarouselTemplate = new isRock.LineBot.CarouselTemplate();

    ////這是範例，所以用一組樣板建立三個
    //CarouselTemplate.columns.Add(Column);
    //        CarouselTemplate.columns.Add(Column);
    //        CarouselTemplate.columns.Add(Column);















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