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

        private readonly LineProductService _lineproductService;
        public LineWebHookController(LineProductService lineproductService)
        {
            _lineproductService = lineproductService;
        }

        public delegate isRock.LineBot.TextMessage selectoption();

        private static Dictionary<string, selectoption> quickdict
            = new Dictionary<string, selectoption>
            {
                { "請選擇遊戲種類" , new selectoption(showCategories) },
                { "請選擇陪玩師性別" , new selectoption(showGenders) },
                { "請選擇陪玩師等級" , new selectoption(showLevels) },
                { "請選擇遊戲產品價格" , new selectoption(showPrice) },
                { "請選擇遊戲伺服器" , new selectoption(showServers) }
            };

        private static isRock.LineBot.TextMessage showCategories()
        {
            isRock.LineBot.TextMessage msg = new isRock.LineBot.TextMessage("EPal Game Categories");
            Dictionary<string, string> categories = new Dictionary<string, string>()
                        {
                            {"League of Legends","https://res.cloudinary.com/djamumruo/image/upload/v1636109116/league-of-legends_vhzld0.jpg"},
                            {"E-Chat","https://res.cloudinary.com/djamumruo/image/upload/v1636109371/echat_gilliu.png"},
                            {"Movie","https://res.cloudinary.com/djamumruo/image/upload/v1636118053/123_gbwopz.png"},
                            {"Valorant","https://res.cloudinary.com/djamumruo/image/upload/v1636118054/valorant_fgkohz.jpg"},
                            {"Custom Game","https://res.cloudinary.com/djamumruo/image/upload/v1636118053/customgame_ed6fk6.png"},
                            {"Minecraft","https://res.cloudinary.com/djamumruo/image/upload/v1636118054/Minecraft_pehjd8.png"},
                            {"Among Us","https://res.cloudinary.com/djamumruo/image/upload/v1636118053/Among_Us_Promo_2018_zahymb.jpg"},
                            {"Apex Legends","https://res.cloudinary.com/djamumruo/image/upload/v1636118053/apex-featured-image-16x9.jpg.adapt.crop16x9.1023w_pheafd.jpg"},
                            {"Teamfight Tactics","https://res.cloudinary.com/djamumruo/image/upload/v1636118054/tft-galaxies-header_xkkld3.jpg"},
                            {"Overwatch","https://res.cloudinary.com/djamumruo/image/upload/v1636118292/overwatch_tapjhi.webp"},
                            {"Sleep Call","https://res.cloudinary.com/djamumruo/image/upload/v1636118054/sellpcall_reovco.png"}
                        };
            foreach (var entry in categories)
            {
                msg.quickReply.items.Add(new isRock.LineBot.QuickReplyMessageAction(entry.Key, entry.Key, new Uri(entry.Value)));
            }
            return msg;
        }

        private static isRock.LineBot.TextMessage showGenders()
        {
            //isRock.LineBot.Bot bot = new isRock.LineBot.Bot("sulLD9jJWPJW3RWQJVhuwL7vqcTOE6wtQCr6NND1ynH8YmUYVe9m4vFKk6OL7vMXDFbuzbN2QG47fPXGEi+g5JXt4H2eDdAEr9hCFnJqAwJDfVlgSHVPYUSGaxokiD36hV1n2BGzpcbPDJkrqMlAVgdB04t89/1O/w1cDnyilFU=");

            isRock.LineBot.TextMessage msg = new isRock.LineBot.TextMessage("EPal Creator Gender");
            Dictionary<string, string> genders = new Dictionary<string, string>()
                        {
                            {"Male","https://res.cloudinary.com/djamumruo/image/upload/v1636118882/male_tlilkj.png"},
                            {"Female","https://res.cloudinary.com/djamumruo/image/upload/v1636118882/female_r2c3ax.png"}
                        };
            foreach (var entry in genders)
            {
                msg.quickReply.items.Add(new isRock.LineBot.QuickReplyMessageAction(entry.Key, entry.Key, new Uri(entry.Value)));
            }
            //bot.PushMessage(UserId, msg);
            return msg;
        }

        private static isRock.LineBot.TextMessage showLevels()
        {
            isRock.LineBot.TextMessage msg = new isRock.LineBot.TextMessage("EPal Creator Level");
            Dictionary<string, string> levels = new Dictionary<string, string>()
                        {
                            {"Bronze","https://res.cloudinary.com/djamumruo/image/upload/v1636118882/bronze-medal_ctlq2m.png"},
                            {"Silver","https://res.cloudinary.com/djamumruo/image/upload/v1636118882/silver-medal_xjpyav.png"},
                            {"Gold","https://res.cloudinary.com/djamumruo/image/upload/v1636118882/gold-medal_zdhiri.png"},
                            {"Platnum","https://res.cloudinary.com/djamumruo/image/upload/v1636118882/platinum_i7wweb.png"},
                            {"Diamond","https://res.cloudinary.com/djamumruo/image/upload/v1636124878/icons8-master-48_swujzl.png"},
                            {"Master","https://res.cloudinary.com/djamumruo/image/upload/v1636124878/icons8-master-48_swujzl.png"},
                            {"Challenger","https://res.cloudinary.com/djamumruo/image/upload/v1636124878/icons8-climbing-16_fchyqb.png"},
                            {"Unranked","https://res.cloudinary.com/djamumruo/image/upload/v1636124878/icons8-bookmark_kvs8zr.gif"},
                        };
            foreach (var entry in levels)
            {
                msg.quickReply.items.Add(new isRock.LineBot.QuickReplyMessageAction(entry.Key, entry.Key, new Uri(entry.Value)));
            }
            return msg;
        }

        private static isRock.LineBot.TextMessage showPrice()
        {
            isRock.LineBot.TextMessage msg = new isRock.LineBot.TextMessage("EPal Game Unitprice");
            Dictionary<string, string> price = new Dictionary<string, string>()
                        {
                            {"$1~$5","https://res.cloudinary.com/djamumruo/image/upload/v1636118882/money-bag_vvjzg6.png"},
                            {"$5~$10","https://res.cloudinary.com/djamumruo/image/upload/v1636118882/money-bag_vvjzg6.png"},
                            {"$10~$20","https://res.cloudinary.com/djamumruo/image/upload/v1636118882/money-bag_vvjzg6.png"},
                            {"$20 up","https://res.cloudinary.com/djamumruo/image/upload/v1636118882/money-bag_vvjzg6.png"}
                        };
            foreach (var entry in price)
            {
                msg.quickReply.items.Add(new isRock.LineBot.QuickReplyMessageAction(entry.Key, entry.Key, new Uri(entry.Value)));
            }
            return msg;
        }

        private static isRock.LineBot.TextMessage showServers()
        {
            isRock.LineBot.TextMessage msg = new isRock.LineBot.TextMessage("EPal Game Server");
            Dictionary<string, string> servers = new Dictionary<string, string>()
                        {
                            {"OCE","https://res.cloudinary.com/djamumruo/image/upload/v1636119151/icons8-server-48_zbdqgm.png"},
                            {"NA","https://res.cloudinary.com/djamumruo/image/upload/v1636119151/icons8-server-48_zbdqgm.png"},
                            {"LAN","https://res.cloudinary.com/djamumruo/image/upload/v1636119151/icons8-server-48_zbdqgm.png"},
                            {"BR","https://res.cloudinary.com/djamumruo/image/upload/v1636119151/icons8-server-48_zbdqgm.png"},
                            {"EU West","https://res.cloudinary.com/djamumruo/image/upload/v1636119151/icons8-server-48_zbdqgm.png"},
                            {"EU NorthEast","https://res.cloudinary.com/djamumruo/image/upload/v1636119151/icons8-server-48_zbdqgm.png"}
                        };
            foreach (var entry in servers)
            {
                msg.quickReply.items.Add(new isRock.LineBot.QuickReplyMessageAction(entry.Key, entry.Key, new Uri(entry.Value)));
            }
            return msg;
        }



        [Route("api/LineBotWebHook")]
        [HttpPost]
        public IActionResult POST()
        {
            this.ChannelAccessToken = "fdB8deMPW51UAuTi+udDZRNVjFvW6EgKHdXEzR83/5F1+pZ/lo/3RjlFMTfM4E0jsCEPBXVGwwj3fEelU+hARcwDWqOMEfGgGIY6A52dXBPb3T+cpQgAEzd8HU1UH0uI+UMJRWk7MZzud1u8YdkB8wdB04t89/1O/w1cDnyilFU=";
            if (ReceivedMessage.events == null || ReceivedMessage.events.Count() <= 0 ||
                ReceivedMessage.events.FirstOrDefault().replyToken == "00000000000000000000000000000000") return Ok();
            var LineEvent = this.ReceivedMessage.events.FirstOrDefault();
            var responseMsg = "";

            //與linebot對話的usedid
            var UserId = this.ReceivedMessage.events[0].source.userId;
            isRock.LineBot.Bot bot = new isRock.LineBot.Bot(ChannelAccessToken);

            try
            {
                var linetype = LineEvent.type.ToLower();
                var linemsgtype = LineEvent.message.type.ToLower();
                var linemsgtext = LineEvent.message.text;
                //string[] lineevent = new string[] { linetype, linemsgtype, linemsgtext };

                var result = quickdict.ContainsKey(linemsgtext);             

                //準備回覆訊息
                if (linetype == "message" && linemsgtype == "text" && result == true)
                {
                    //_expressions[lineevent].Invoke(UserId);
                    var msg = quickdict[linemsgtext].Invoke();
                    bot.PushMessage(UserId, msg);
                    return Ok();
                }
                else if (linetype == "message" && linemsgtype == "text" && linemsgtext == "關於EPal")
                {
                    responseMsg = "EPal提供您客製化的遊戲服務平台，可點選各功能鍵，篩選出適合您的陪玩師，並連結至EPal網站，查看遊戲產品明細。\n\n" +
                                  "於訊息視窗輸入關鍵字可能無法正確找到相關商品，請務必優先透過選單進行篩選。";
                }
                else if(linetype == "message" && linemsgtype == "text")
                {
                    bool reply = GetResult(LineEvent.message.text, LineEvent.replyToken, UserId);
                    return Ok();
                }
                else if (linetype == "message" && linemsgtype == "sticker")
                {
                    this.ReplyMessage(LineEvent.replyToken, 1, 2);
                    return Ok();
                }
                else if (linetype == "message")
                {
                    responseMsg = $"收到 event : {LineEvent.type} type: {LineEvent.message.type} ";
                }
                else
                {
                    responseMsg = $"收到 event : {LineEvent.type} ";
                }

                this.ReplyMessage(LineEvent.replyToken, responseMsg);
                return Ok();

            }
            catch (Exception ex)
            {
                //this.PushMessage(UserId, "發生錯誤:\n" + ex.Message);
                return Ok();
            }
        }






        //public static IEnumerable<LineProductViewModel> getallpro()
        //{
        //    return _lineproductService.GetAllProduct();
        //}


        //public delegate isRock.LineBot.CarouselTemplate carouselresult();

        //private static Dictionary<bool, carouselresult> carouseldict
        //    = new Dictionary<bool, carouselresult>
        //    {
        //        { true , new carouselresult(categorytem) },
        //        //{ "請選擇陪玩師性別" , new selectoption(showGenders) },
        //        //{ "請選擇陪玩師等級" , new selectoption(showLevels) },
        //        //{ "請選擇遊戲產品價格" , new selectoption(showPrice) },
        //        //{ "請選擇遊戲伺服器" , new selectoption(showServers) }
        //    };









        public delegate bool MyKey(string userInput, List<LineProductViewModel> allproduct);
        public delegate void MyValue(string userInput, List<LineProductViewModel> allproduct, string userToken);

        private bool isCategory(string keyword, List<LineProductViewModel> allproduct)
        {
            //var result = _lineproductService.GetAllProduct();

            //判斷遊戲種類
            bool gamename = allproduct.Any(x => x.GameName == keyword);
            return gamename;
        }

        private bool isGender(string keyword, List<LineProductViewModel> allproduct)
        {
            //var result = _lineproductService.GetAllProduct();

            //判斷性別
            int genderenum = 1;
            bool gender;
            switch (keyword)
            {
                case "Male":
                    gender = allproduct.Any(x => x.gender == 1);
                    genderenum = 1;
                    break;
                case "Female":
                    gender = allproduct.Any(x => x.gender == 2);
                    genderenum = 2;
                    break;
                default:
                    gender = false;
                    break;
            }
            return gender;
        }

        private bool isLevel(string keyword, List<LineProductViewModel> allproduct)
        {
            //var result = _lineproductService.GetAllProduct();

            //判斷陪玩師等級
            bool level = allproduct.Any(x => x.Level == keyword);
            return level;
        }

        private bool isPrice(string keyword, List<LineProductViewModel> allproduct)
        {
            //var result = _lineproductService.GetAllProduct();

            //判斷遊戲產品價格
            bool productprice;
            switch (keyword)
            {
                case "$1~$5":
                    productprice = allproduct.Any(x => x.UnitPrice >= 1M && x.UnitPrice <= 5M);
                    break;
                case "$5~$10":
                    productprice = allproduct.Any(x => x.UnitPrice >= 5M && x.UnitPrice <= 10M);
                    break;
                case "$10~$20":
                    productprice = allproduct.Any(x => x.UnitPrice >= 10M && x.UnitPrice <= 20M);
                    break;
                case "$20 up":
                    productprice = allproduct.Any(x => x.UnitPrice >= 20M);
                    break;
                default:
                    productprice = false;
                    break;
            }
            return productprice;
        }

        private bool isServer(string keyword, List<LineProductViewModel> allproduct)
        {
            //var result = _lineproductService.GetAllProduct();

            //判斷遊戲伺服器
            bool server = allproduct.Any(x => x.Server == keyword);
            return server;
        }


        private void showCategory(string keyword, List<LineProductViewModel> allproduct, string userToken)
        {

            //CarouselTemplate
            var CarouselTemplate = new isRock.LineBot.CarouselTemplate();
            var rnd = new Random();

            var bycat = allproduct.Where(x => x.GameName == keyword).Select(x => new LineProductViewModel()
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
            ReplyMessage(userToken, CarouselTemplate);

        }

        private void showGender(string keyword, List<LineProductViewModel> allproduct, string userToken)
        {

            //CarouselTemplate
            var CarouselTemplate = new isRock.LineBot.CarouselTemplate();
            var rnd = new Random();

            var genderlist = new List<LineProductViewModel>();
            switch (keyword)
            {
                case "Male":
                    genderlist = allproduct.Where(x => x.gender == 1).ToList();
                    break;
                case "Female":
                    genderlist = allproduct.Where(x => x.gender == 2).ToList();
                    break;
                default:
                    genderlist = null;
                    break;
            }

            var bycat = genderlist.Select(x => new LineProductViewModel()
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
            ReplyMessage(userToken, CarouselTemplate);

        }


        private void showLevel(string keyword, List<LineProductViewModel> allproduct, string userToken)
        {

            //CarouselTemplate
            var CarouselTemplate = new isRock.LineBot.CarouselTemplate();
            var rnd = new Random();

            var bycat = allproduct.Where(x => x.Level == keyword).Select(x => new LineProductViewModel()
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
            ReplyMessage(userToken, CarouselTemplate);
        }

        private void showPrice(string keyword, List<LineProductViewModel> allproduct, string userToken)
        {

            //CarouselTemplate
            var CarouselTemplate = new isRock.LineBot.CarouselTemplate();
            var rnd = new Random();

            var pricelist = new List<LineProductViewModel>();
            //判斷遊戲產品價格
            switch (keyword)
            {
                case "$1~$5":
                    pricelist = allproduct.Where(x => x.UnitPrice >= 1M && x.UnitPrice <= 5M).ToList();
                    break;
                case "$5~$10":
                    pricelist = allproduct.Where(x => x.UnitPrice >= 5M && x.UnitPrice <= 10M).ToList();
                    break;
                case "$10~$20":
                    pricelist = allproduct.Where(x => x.UnitPrice >= 10M && x.UnitPrice <= 20M).ToList();
                    break;
                case "$20 up":
                    pricelist = allproduct.Where(x => x.UnitPrice >= 20M).ToList();
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
            ReplyMessage(userToken, CarouselTemplate);
        }

        private void showServer(string keyword, List<LineProductViewModel> allproduct, string userToken)
        {

            //CarouselTemplate
            var CarouselTemplate = new isRock.LineBot.CarouselTemplate();
            var rnd = new Random();

            var bycat = allproduct.Where(x => x.Server == keyword).Select(x => new LineProductViewModel()
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
            ReplyMessage(userToken, CarouselTemplate);
        }


        public bool GetResult(string keyword, string token, string UserId)
        {
            //string Default = "很抱歉，關鍵字有誤";
            if (keyword == null)
            {
                return false;
                //return Default;
            }


            //CarouselTemplate
            var CarouselTemplate = new isRock.LineBot.CarouselTemplate();

            //int genderenum = 0;
            try
            {

                var result = _lineproductService.GetAllProduct().ToList();

                string userInput = keyword;
                List <LineProductViewModel> allproduct= result;
                string userToken = token;

                Dictionary<MyKey, MyValue> d = new Dictionary<MyKey, MyValue>()
                    {
                     {new MyKey(isCategory),  new MyValue(showCategory) },
                     {new MyKey(isGender),  new MyValue(showGender) },
                     {new MyKey(isLevel),  new MyValue(showLevel) },
                     {new MyKey(isPrice),  new MyValue(showPrice) },
                     {new MyKey(isServer),  new MyValue(showServer) },
                    };
                //挑選出Key的回傳值為true的Method來執行
                d.Where(x => x.Key(userInput, allproduct) == true).FirstOrDefault().Value.Invoke(userInput, allproduct, userToken);
                return true;


                ////判斷遊戲種類
                //bool gamename = result.Any(x => x.GameName == keyword);
                ////判斷陪玩師等級
                //bool level = result.Any(x => x.Level == keyword);
                ////判斷遊戲伺服器
                //bool server = result.Any(x => x.Server == keyword);

                ////判斷性別
                //bool gender;
                //switch (keyword)
                //{
                //    case "Male":
                //        gender = result.Any(x => x.gender == 0);
                //        genderenum = 0;
                //        break;
                //    case "Female":
                //        gender = result.Any(x => x.gender == 1);
                //        genderenum = 1;
                //        break;
                //    default:
                //        gender = false;
                //        break;
                //}

                ////判斷遊戲產品價格
                //bool productprice;
                //switch (keyword)
                //{
                //    case "$1~$5":
                //        productprice = result.Any(x => x.UnitPrice >= 1M && x.UnitPrice <= 5M);
                //        break;
                //    case "$5~$10":
                //        productprice = result.Any(x => x.UnitPrice >= 5M && x.UnitPrice <= 10M);
                //        break;
                //    case "$10~$20":
                //        productprice = result.Any(x => x.UnitPrice >= 10M && x.UnitPrice <= 20M);
                //        break;
                //    case "$20 up":
                //        productprice = result.Any(x => x.UnitPrice >= 20M);
                //        break;
                //    default:
                //        productprice = false;
                //        break;
                //}


                //var rnd = new Random();
                ////string replymsg = "";

                //if (gamename)
                //{
                //    var bycat = result.Where(x => x.GameName == keyword).Select(x => new LineProductViewModel()
                //    {
                //        ProductId = x.ProductId,
                //        UnitPrice = x.UnitPrice,
                //        MemberName = x.MemberName,
                //        GameName = x.GameName,
                //        Server = x.Server,
                //        Level = x.Level,
                //        Position = x.Position,
                //        CreatorImg = x.CreatorImg
                //    })
                //                        .OrderBy(x => rnd.Next()).Take(5);

                //    foreach (var cat in bycat)
                //    {
                //        var creatorimg = cat.CreatorImg;
                //        var memberName = cat.MemberName;
                //        var price = cat.UnitPrice.ToString();
                //        var proId = cat.ProductId;

                //        var prourl = string.Format("https://epal-frontstage.azurewebsites.net/ePals/Detail/{0}",
                //            proId);

                //        var carouseltext = string.Format("{0} {1}${2}",
                //                    cat.MemberName,
                //                    Environment.NewLine,
                //                    cat.UnitPrice);

                //        var actions = new List<isRock.LineBot.TemplateActionBase>();
                //        actions.Add(new isRock.LineBot.UriAction() { label = "Go To Detail Page", uri = new Uri(prourl) });

                //        var Column = new isRock.LineBot.Column
                //        {
                //            text = carouseltext,
                //            title = keyword,
                //            thumbnailImageUrl = new Uri(creatorimg),
                //            actions = actions
                //        };

                //        CarouselTemplate.columns.Add(Column);

                //    }

                //}
                //else if (gender)
                //{
                //    var bycat = result.Where(x => x.gender == genderenum).Select(x => new LineProductViewModel()
                //    {
                //        ProductId = x.ProductId,
                //        UnitPrice = x.UnitPrice,
                //        MemberName = x.MemberName,
                //        GameName = x.GameName,
                //        Server = x.Server,
                //        Level = x.Level,
                //        Position = x.Position,
                //        CreatorImg = x.CreatorImg
                //    })
                //                        .OrderBy(x => rnd.Next()).Take(5);

                //    foreach (var cat in bycat)
                //    {
                //        var creatorimg = cat.CreatorImg;
                //        var memberName = cat.MemberName;
                //        var price = cat.UnitPrice.ToString();
                //        var proId = cat.ProductId;
                //        var productname = cat.GameName;

                //        var prourl = string.Format("https://epal-frontstage.azurewebsites.net/ePals/Detail/{0}",
                //            proId);

                //        var carouseltext = string.Format("{0} {1}${2}",
                //                    cat.MemberName,
                //                    Environment.NewLine,
                //                    cat.UnitPrice);

                //        var actions = new List<isRock.LineBot.TemplateActionBase>();
                //        actions.Add(new isRock.LineBot.UriAction() { label = "Go To Detail Page", uri = new Uri(prourl) });

                //        var Column = new isRock.LineBot.Column
                //        {
                //            text = carouseltext,
                //            title = productname,
                //            thumbnailImageUrl = new Uri(creatorimg),
                //            actions = actions
                //        };
                //        CarouselTemplate.columns.Add(Column);

                //    }
                //}
                //else if (level)
                //{
                //    var bycat = result.Where(x => x.Level == keyword).Select(x => new LineProductViewModel()
                //    {
                //        ProductId = x.ProductId,
                //        UnitPrice = x.UnitPrice,
                //        MemberName = x.MemberName,
                //        GameName = x.GameName,
                //        Server = x.Server,
                //        Level = x.Level,
                //        Position = x.Position,
                //        CreatorImg = x.CreatorImg
                //    })
                //                        .OrderBy(x => rnd.Next()).Take(5);

                //    foreach (var cat in bycat)
                //    {
                //        var creatorimg = cat.CreatorImg;
                //        var memberName = cat.MemberName;
                //        var price = cat.UnitPrice.ToString();
                //        var proId = cat.ProductId;
                //        var productname = cat.GameName;

                //        var prourl = string.Format("https://epal-frontstage.azurewebsites.net/ePals/Detail/{0}",
                //            proId);

                //        var carouseltext = string.Format("{0} {1}${2}",
                //                    cat.MemberName,
                //                    Environment.NewLine,
                //                    cat.UnitPrice);

                //        var actions = new List<isRock.LineBot.TemplateActionBase>();
                //        actions.Add(new isRock.LineBot.UriAction() { label = "Go To Detail Page", uri = new Uri(prourl) });

                //        var Column = new isRock.LineBot.Column
                //        {
                //            text = carouseltext,
                //            title = productname,
                //            thumbnailImageUrl = new Uri(creatorimg),
                //            actions = actions
                //        };
                //        CarouselTemplate.columns.Add(Column);

                //    }
                //}
                //else if (productprice)
                //{
                //    var pricelist = new List<LineProductViewModel>();
                //    //判斷遊戲產品價格
                //    switch (keyword)
                //    {
                //        case "$1~$5":
                //            pricelist = result.Where(x => x.UnitPrice >= 1M && x.UnitPrice <= 5M).ToList();
                //            break;
                //        case "$5~$10":
                //            pricelist = result.Where(x => x.UnitPrice >= 5M && x.UnitPrice <= 10M).ToList();
                //            break;
                //        case "$10~$20":
                //            pricelist = result.Where(x => x.UnitPrice >= 10M && x.UnitPrice <= 20M).ToList();
                //            break;
                //        case "$20 up":
                //            pricelist = result.Where(x => x.UnitPrice >= 20M).ToList();
                //            break;
                //        default:
                //            pricelist = null;
                //            break;
                //    }

                //    var bycat = pricelist.Select(x => new LineProductViewModel()
                //    {
                //        ProductId = x.ProductId,
                //        UnitPrice = x.UnitPrice,
                //        MemberName = x.MemberName,
                //        GameName = x.GameName,
                //        Server = x.Server,
                //        Level = x.Level,
                //        Position = x.Position,
                //        CreatorImg = x.CreatorImg
                //    })
                //                        .OrderBy(x => rnd.Next()).Take(5);

                //    foreach (var cat in bycat)
                //    {
                //        var creatorimg = cat.CreatorImg;
                //        var memberName = cat.MemberName;
                //        var price = cat.UnitPrice.ToString();
                //        var proId = cat.ProductId;
                //        var productname = cat.GameName;

                //        var prourl = string.Format("https://epal-frontstage.azurewebsites.net/ePals/Detail/{0}",
                //            proId);

                //        var carouseltext = string.Format("{0} {1}${2}",
                //                    cat.MemberName,
                //                    Environment.NewLine,
                //                    cat.UnitPrice);

                //        var actions = new List<isRock.LineBot.TemplateActionBase>();
                //        actions.Add(new isRock.LineBot.UriAction() { label = "Go To Detail Page", uri = new Uri(prourl) });

                //        var Column = new isRock.LineBot.Column
                //        {
                //            text = carouseltext,
                //            title = productname,
                //            thumbnailImageUrl = new Uri(creatorimg),
                //            actions = actions
                //        };
                //        CarouselTemplate.columns.Add(Column);

                //    }
                //}
                //else if (server)
                //{
                //    var bycat = result.Where(x => x.Server == keyword).Select(x => new LineProductViewModel()
                //    {
                //        ProductId = x.ProductId,
                //        UnitPrice = x.UnitPrice,
                //        MemberName = x.MemberName,
                //        GameName = x.GameName,
                //        Server = x.Server,
                //        Level = x.Level,
                //        Position = x.Position,
                //        CreatorImg = x.CreatorImg
                //    })
                //                        .OrderBy(x => rnd.Next()).Take(5);

                //    foreach (var cat in bycat)
                //    {
                //        var creatorimg = cat.CreatorImg;
                //        var memberName = cat.MemberName;
                //        var price = cat.UnitPrice.ToString();
                //        var proId = cat.ProductId;
                //        var productname = cat.GameName;

                //        var prourl = string.Format("https://epal-frontstage.azurewebsites.net/ePals/Detail/{0}",
                //            proId);

                //        var carouseltext = string.Format("{0} {1}${2}",
                //                    cat.MemberName,
                //                    Environment.NewLine,
                //                    cat.UnitPrice);

                //        var actions = new List<isRock.LineBot.TemplateActionBase>();
                //        actions.Add(new isRock.LineBot.UriAction() { label = "Go To Detail Page", uri = new Uri(prourl) });

                //        var Column = new isRock.LineBot.Column
                //        {
                //            text = carouseltext,
                //            title = productname,
                //            thumbnailImageUrl = new Uri(creatorimg),
                //            actions = actions
                //        };
                //        CarouselTemplate.columns.Add(Column);

                //    }
                //}
                //else
                //{
                //    ReplyMessage(token, "Don't enter text directly. Please see about us!");
                //    return false;
                //}
                ////Default = "找不到相關商品";
                ////return Default;


            }
            catch (Exception ex)
            {
                ReplyMessage(token, "Error!");
                return false;
                //return Default;
            }


            //ReplyMessage(token, CarouselTemplate);
            //return true;
        }














        //[Route("api/LineBotWebHook")]
        //[HttpPost]
        //public IActionResult POST()
        //{
        //    //設定ChannelAccessToken
        //    this.ChannelAccessToken = "sulLD9jJWPJW3RWQJVhuwL7vqcTOE6wtQCr6NND1ynH8YmUYVe9m4vFKk6OL7vMXDFbuzbN2QG47fPXGEi+g5JXt4H2eDdAEr9hCFnJqAwJDfVlgSHVPYUSGaxokiD36hV1n2BGzpcbPDJkrqMlAVgdB04t89/1O/w1cDnyilFU=";
        //    //配合Line Verify
        //    if (ReceivedMessage.events == null || ReceivedMessage.events.Count() <= 0 ||
        //        ReceivedMessage.events.FirstOrDefault().replyToken == "00000000000000000000000000000000") return Ok();
        //    //取得Line Event
        //    var LineEvent = this.ReceivedMessage.events.FirstOrDefault();
        //    var responseMsg = "";

        //    //抓當前與linebot對話的usedid
        //    //var user = this.GetUserInfo(LineEvent.source.userId);
        //    var UserId = this.ReceivedMessage.events[0].source.userId;

        //    try
        //    {
        //        //準備回覆訊息
        //        if (LineEvent.message.text == "請選擇遊戲種類")
        //        {
        //            isRock.LineBot.TextMessage msg = new isRock.LineBot.TextMessage("EPal Game Categories");

        //            msg.quickReply.items.Add(
        //                new isRock.LineBot.QuickReplyMessageAction(
        //                    "League of Legends", "League of Legends", new Uri("https://res.cloudinary.com/djamumruo/image/upload/v1636109116/league-of-legends_vhzld0.jpg")));
        //            msg.quickReply.items.Add(
        //                new isRock.LineBot.QuickReplyMessageAction(
        //                    "E-Chat", "E-Chat", new Uri("https://res.cloudinary.com/djamumruo/image/upload/v1636109371/echat_gilliu.png")));
        //            msg.quickReply.items.Add(
        //                new isRock.LineBot.QuickReplyMessageAction(
        //                    "Movie", "Movie", new Uri("https://res.cloudinary.com/djamumruo/image/upload/v1636118053/123_gbwopz.png")));
        //            msg.quickReply.items.Add(
        //                new isRock.LineBot.QuickReplyMessageAction(
        //                    "Valorant", "Valorant", new Uri("https://res.cloudinary.com/djamumruo/image/upload/v1636118054/valorant_fgkohz.jpg")));
        //            msg.quickReply.items.Add(
        //                new isRock.LineBot.QuickReplyMessageAction(
        //                    "Custom Game", "Custom Game", new Uri("https://res.cloudinary.com/djamumruo/image/upload/v1636118053/customgame_ed6fk6.png")));
        //            msg.quickReply.items.Add(
        //                new isRock.LineBot.QuickReplyMessageAction(
        //                    "Minecraft", "Minecraft", new Uri("https://res.cloudinary.com/djamumruo/image/upload/v1636118054/Minecraft_pehjd8.png")));
        //            msg.quickReply.items.Add(
        //                new isRock.LineBot.QuickReplyMessageAction(
        //                    "Among Us", "Among Us", new Uri("https://res.cloudinary.com/djamumruo/image/upload/v1636118053/Among_Us_Promo_2018_zahymb.jpg")));
        //            msg.quickReply.items.Add(
        //                new isRock.LineBot.QuickReplyMessageAction(
        //                    "Apex Legends", "Apex Legends", new Uri("https://res.cloudinary.com/djamumruo/image/upload/v1636118053/apex-featured-image-16x9.jpg.adapt.crop16x9.1023w_pheafd.jpg")));
        //            msg.quickReply.items.Add(
        //                new isRock.LineBot.QuickReplyMessageAction(
        //                    "Teamfight Tactics", "Teamfight Tactics", new Uri("https://res.cloudinary.com/djamumruo/image/upload/v1636118054/tft-galaxies-header_xkkld3.jpg")));
        //            msg.quickReply.items.Add(
        //                new isRock.LineBot.QuickReplyMessageAction(
        //                    "Overwatch", "Overwatch", new Uri("https://res.cloudinary.com/djamumruo/image/upload/v1636118292/overwatch_tapjhi.webp")));
        //            msg.quickReply.items.Add(
        //                new isRock.LineBot.QuickReplyMessageAction(
        //                    "Sleep Call", "Sleep Call", new Uri("https://res.cloudinary.com/djamumruo/image/upload/v1636118054/sellpcall_reovco.png")));
        //            //msg.quickReply.items.Add(
        //            //    new isRock.LineBot.QuickReplyMessageAction(
        //            //        "Animal Crossing: New Horizons", "Animal Crossing: New Horizons", new Uri("https://arock.blob.core.windows.net/blogdata201809/if_emoji_emoticon-35_3638429.png")));
        //            //msg.quickReply.items.Add(
        //            //    new isRock.LineBot.QuickReplyMessageAction(
        //            //        "Others", "Others", new Uri("https://arock.blob.core.windows.net/blogdata201809/if_emoji_emoticon-35_3638429.png")));


        //            isRock.LineBot.Bot bot = new isRock.LineBot.Bot(ChannelAccessToken);
        //            bot.PushMessage(UserId, msg);
        //            return Ok();

        //        }
        //        else if (LineEvent.message.text == "請選擇陪玩師性別")
        //        {
        //            isRock.LineBot.TextMessage msg = new isRock.LineBot.TextMessage("EPal Creator Gender");

        //            msg.quickReply.items.Add(
        //                new isRock.LineBot.QuickReplyMessageAction(
        //                    "Male", "Male", new Uri("https://res.cloudinary.com/djamumruo/image/upload/v1636118882/male_tlilkj.png")));
        //            msg.quickReply.items.Add(
        //                new isRock.LineBot.QuickReplyMessageAction(
        //                    "Female", "Female", new Uri("https://res.cloudinary.com/djamumruo/image/upload/v1636118882/female_r2c3ax.png")));

        //            isRock.LineBot.Bot bot = new isRock.LineBot.Bot(ChannelAccessToken);
        //            bot.PushMessage(UserId, msg);
        //            return Ok();

        //        }
        //        else if (LineEvent.message.text == "請選擇陪玩師等級")
        //        {
        //            isRock.LineBot.TextMessage msg = new isRock.LineBot.TextMessage("EPal Creator Level");

        //            msg.quickReply.items.Add(
        //                new isRock.LineBot.QuickReplyMessageAction(
        //                    "Bronze", "Bronze", new Uri("https://res.cloudinary.com/djamumruo/image/upload/v1636118882/bronze-medal_ctlq2m.png")));
        //            msg.quickReply.items.Add(
        //                new isRock.LineBot.QuickReplyMessageAction(
        //                    "Silver", "Silver", new Uri("https://res.cloudinary.com/djamumruo/image/upload/v1636118882/silver-medal_xjpyav.png")));
        //            msg.quickReply.items.Add(
        //                new isRock.LineBot.QuickReplyMessageAction(
        //                    "Gold", "Gold", new Uri("https://res.cloudinary.com/djamumruo/image/upload/v1636118882/gold-medal_zdhiri.png")));
        //            msg.quickReply.items.Add(
        //                new isRock.LineBot.QuickReplyMessageAction(
        //                    "Platnum", "Platnum", new Uri("https://res.cloudinary.com/djamumruo/image/upload/v1636118882/platinum_i7wweb.png")));
        //            msg.quickReply.items.Add(
        //                new isRock.LineBot.QuickReplyMessageAction(
        //                    "Diamond", "Diamond", new Uri("https://res.cloudinary.com/djamumruo/image/upload/v1636118882/diamond_wpbsda.png")));
        //            msg.quickReply.items.Add(
        //                new isRock.LineBot.QuickReplyMessageAction(
        //                    "Master", "Master", new Uri("https://res.cloudinary.com/djamumruo/image/upload/v1636124878/icons8-master-48_swujzl.png")));
        //            msg.quickReply.items.Add(
        //                new isRock.LineBot.QuickReplyMessageAction(
        //                    "Challenger", "Challenger", new Uri("https://res.cloudinary.com/djamumruo/image/upload/v1636124878/icons8-climbing-16_fchyqb.png")));
        //            msg.quickReply.items.Add(
        //                new isRock.LineBot.QuickReplyMessageAction(
        //                    "Unranked", "Unranked", new Uri("https://res.cloudinary.com/djamumruo/image/upload/v1636124878/icons8-bookmark_kvs8zr.gif")));

        //            isRock.LineBot.Bot bot = new isRock.LineBot.Bot(ChannelAccessToken);
        //            bot.PushMessage(UserId, msg);
        //            return Ok();

        //        }
        //        else if (LineEvent.message.text == "請選擇遊戲產品價格")
        //        {
        //            isRock.LineBot.TextMessage msg = new isRock.LineBot.TextMessage("EPal Game Unitprice");

        //            msg.quickReply.items.Add(
        //                new isRock.LineBot.QuickReplyMessageAction(
        //                    "$1~$5", "$1~$5", new Uri("https://res.cloudinary.com/djamumruo/image/upload/v1636118882/money-bag_vvjzg6.png")));
        //            msg.quickReply.items.Add(
        //                new isRock.LineBot.QuickReplyMessageAction(
        //                    "$5~$10", "$5~$10", new Uri("https://res.cloudinary.com/djamumruo/image/upload/v1636118882/money-bag_vvjzg6.png")));
        //            msg.quickReply.items.Add(
        //                new isRock.LineBot.QuickReplyMessageAction(
        //                    "$10~$20", "$10~$20", new Uri("https://res.cloudinary.com/djamumruo/image/upload/v1636118882/money-bag_vvjzg6.png")));
        //            msg.quickReply.items.Add(
        //                new isRock.LineBot.QuickReplyMessageAction(
        //                    "$20 up", "$20 up", new Uri("https://res.cloudinary.com/djamumruo/image/upload/v1636118882/money-bag_vvjzg6.png")));

        //            isRock.LineBot.Bot bot = new isRock.LineBot.Bot(ChannelAccessToken);
        //            bot.PushMessage(UserId, msg);
        //            return Ok();

        //        }
        //        else if (LineEvent.message.text == "請選擇遊戲伺服器")
        //        {
        //            isRock.LineBot.TextMessage msg = new isRock.LineBot.TextMessage("EPal Game Server");

        //            msg.quickReply.items.Add(
        //                new isRock.LineBot.QuickReplyMessageAction(
        //                    "OCE", "OCE", new Uri("https://res.cloudinary.com/djamumruo/image/upload/v1636119151/icons8-server-48_zbdqgm.png")));
        //            msg.quickReply.items.Add(
        //                new isRock.LineBot.QuickReplyMessageAction(
        //                    "NA", "NA", new Uri("https://res.cloudinary.com/djamumruo/image/upload/v1636119151/icons8-server-48_zbdqgm.png")));
        //            msg.quickReply.items.Add(
        //                new isRock.LineBot.QuickReplyMessageAction(
        //                    "LAN", "LAN", new Uri("https://res.cloudinary.com/djamumruo/image/upload/v1636119151/icons8-server-48_zbdqgm.png")));
        //            msg.quickReply.items.Add(
        //                new isRock.LineBot.QuickReplyMessageAction(
        //                    "BR", "BR", new Uri("https://res.cloudinary.com/djamumruo/image/upload/v1636119151/icons8-server-48_zbdqgm.png")));
        //            msg.quickReply.items.Add(
        //                new isRock.LineBot.QuickReplyMessageAction(
        //                    "EU West", "EU West", new Uri("https://res.cloudinary.com/djamumruo/image/upload/v1636119151/icons8-server-48_zbdqgm.png")));
        //            msg.quickReply.items.Add(
        //                new isRock.LineBot.QuickReplyMessageAction(
        //                    "EU NorthEast", "EU NorthEast", new Uri("https://res.cloudinary.com/djamumruo/image/upload/v1636119151/icons8-server-48_zbdqgm.png")));

        //            isRock.LineBot.Bot bot = new isRock.LineBot.Bot(ChannelAccessToken);
        //            bot.PushMessage(UserId, msg);
        //            return Ok();

        //        }
        //        else if (LineEvent.message.text == "關於EPal")
        //        {
        //            responseMsg = "EPal提供您客製化的遊戲服務平台，可點選各功能鍵，篩選出適合您的陪玩師，並連結至EPal網站，查看遊戲產品明細。\n" +
        //                          "於訊息視窗輸入關鍵字可能無法正確找到相關商品，請務必優先透過選單進行篩選。";
        //        }
        //        else if (LineEvent.type.ToLower() == "message" && LineEvent.message.type.ToLower() == "text")
        //        {
        //            //responseMsg += GetResult(LineEvent.message.text);
        //            bool reply = GetResult(LineEvent.message.text, LineEvent.replyToken, UserId);
        //            return Ok();

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
        //        {
        //            responseMsg = $"收到 event : {LineEvent.type} ";
        //        }

        //        //回覆訊息
        //        this.ReplyMessage(LineEvent.replyToken, responseMsg);
        //        //response OK
        //        return Ok();

        //    }
        //    catch (Exception ex)
        //    {
        //        //回覆訊息
        //        this.PushMessage(UserId, "發生錯誤:\n" + ex.Message);
        //        //response OK
        //        return Ok();
        //    }
        //}







        //public bool GetResult(string keyword, string token, string UserId)
        //{
        //    //string Default = "很抱歉，關鍵字有誤";
        //    if (keyword == null)
        //    {
        //        return false;
        //        //return Default;
        //    }


        //    //CarouselTemplate
        //    var CarouselTemplate = new isRock.LineBot.CarouselTemplate();

        //    //int gendernum = keyword == "Male" ? 0 : 1;
        //    int genderenum = 0;
        //    try
        //    {
        //        var result = _lineproductService.GetAllProduct();

        //        //判斷遊戲種類
        //        bool gamename = result.Any(x => x.GameName == keyword);
        //        ////判斷性別
        //        //bool gender = result.Any(x => x.gender == gendernum);
        //        //判斷陪玩師等級
        //        bool level = result.Any(x => x.Level == keyword);
        //        //判斷遊戲伺服器
        //        bool server = result.Any(x => x.Server == keyword);

        //        //判斷性別
        //        bool gender;
        //        switch (keyword)
        //        {
        //            case "Male":
        //                gender = result.Any(x => x.gender == 0);
        //                genderenum = 0;
        //                break;
        //            case "Female":
        //                gender = result.Any(x => x.gender == 1);
        //                genderenum = 1;
        //                break;
        //            default:
        //                gender = false;
        //                break;
        //        }

        //        //判斷遊戲產品價格
        //        bool productprice;
        //        switch (keyword)
        //        {
        //            case "$1~$5":
        //                productprice = result.Any(x => x.UnitPrice >= 1M && x.UnitPrice <= 5M);
        //                break;
        //            case "$5~$10":
        //                productprice = result.Any(x => x.UnitPrice >= 5M && x.UnitPrice <= 10M);
        //                break;
        //            case "$10~$20":
        //                productprice = result.Any(x => x.UnitPrice >= 10M && x.UnitPrice <= 20M);
        //                break;
        //            case "$20 up":
        //                productprice = result.Any(x => x.UnitPrice >= 20M);
        //                break;
        //            default:
        //                productprice = false;
        //                break;
        //        }


        //        var rnd = new Random();
        //        //string replymsg = "";

        //        if (gamename)
        //        {
        //            var bycat = result.Where(x => x.GameName == keyword).Select(x => new LineProductViewModel()
        //            {
        //                ProductId = x.ProductId,
        //                UnitPrice = x.UnitPrice,
        //                MemberName = x.MemberName,
        //                GameName = x.GameName,
        //                Server = x.Server,
        //                Level = x.Level,
        //                Position = x.Position,
        //                CreatorImg = x.CreatorImg
        //            })
        //                                .OrderBy(x => rnd.Next()).Take(5);

        //            foreach (var cat in bycat)
        //            {
        //                var creatorimg = cat.CreatorImg;
        //                var memberName = cat.MemberName;
        //                var price = cat.UnitPrice.ToString();
        //                var proId = cat.ProductId;

        //                var prourl = string.Format("https://epal-frontstage.azurewebsites.net/ePals/Detail/{0}",
        //                    proId);

        //                var carouseltext = string.Format("{0} {1}${2}",
        //                            cat.MemberName,
        //                            Environment.NewLine,
        //                            cat.UnitPrice);

        //                var actions = new List<isRock.LineBot.TemplateActionBase>();
        //                actions.Add(new isRock.LineBot.UriAction() { label = "Go To Detail Page", uri = new Uri(prourl) });

        //                var Column = new isRock.LineBot.Column
        //                {
        //                    text = carouseltext,
        //                    title = keyword,
        //                    thumbnailImageUrl = new Uri(creatorimg),
        //                    actions = actions
        //                };

        //                CarouselTemplate.columns.Add(Column);

        //            }

        //        }
        //        else if (gender)
        //        {
        //            var bycat = result.Where(x => x.gender == genderenum).Select(x => new LineProductViewModel()
        //            {
        //                ProductId = x.ProductId,
        //                UnitPrice = x.UnitPrice,
        //                MemberName = x.MemberName,
        //                GameName = x.GameName,
        //                Server = x.Server,
        //                Level = x.Level,
        //                Position = x.Position,
        //                CreatorImg = x.CreatorImg
        //            })
        //                                .OrderBy(x => rnd.Next()).Take(5);

        //            foreach (var cat in bycat)
        //            {
        //                var creatorimg = cat.CreatorImg;
        //                var memberName = cat.MemberName;
        //                var price = cat.UnitPrice.ToString();
        //                var proId = cat.ProductId;
        //                var productname = cat.GameName;

        //                var prourl = string.Format("https://epal-frontstage.azurewebsites.net/ePals/Detail/{0}",
        //                    proId);

        //                var carouseltext = string.Format("{0} {1}${2}",
        //                            cat.MemberName,
        //                            Environment.NewLine,
        //                            cat.UnitPrice);

        //                var actions = new List<isRock.LineBot.TemplateActionBase>();
        //                actions.Add(new isRock.LineBot.UriAction() { label = "Go To Detail Page", uri = new Uri(prourl) });

        //                var Column = new isRock.LineBot.Column
        //                {
        //                    text = carouseltext,
        //                    title = productname,
        //                    thumbnailImageUrl = new Uri(creatorimg),
        //                    actions = actions
        //                };
        //                CarouselTemplate.columns.Add(Column);

        //            }
        //        }
        //        else if (level)
        //        {
        //            var bycat = result.Where(x => x.Level == keyword).Select(x => new LineProductViewModel()
        //            {
        //                ProductId = x.ProductId,
        //                UnitPrice = x.UnitPrice,
        //                MemberName = x.MemberName,
        //                GameName = x.GameName,
        //                Server = x.Server,
        //                Level = x.Level,
        //                Position = x.Position,
        //                CreatorImg = x.CreatorImg
        //            })
        //                                .OrderBy(x => rnd.Next()).Take(5);

        //            foreach (var cat in bycat)
        //            {
        //                var creatorimg = cat.CreatorImg;
        //                var memberName = cat.MemberName;
        //                var price = cat.UnitPrice.ToString();
        //                var proId = cat.ProductId;
        //                var productname = cat.GameName;

        //                var prourl = string.Format("https://epal-frontstage.azurewebsites.net/ePals/Detail/{0}",
        //                    proId);

        //                var carouseltext = string.Format("{0} {1}${2}",
        //                            cat.MemberName,
        //                            Environment.NewLine,
        //                            cat.UnitPrice);

        //                var actions = new List<isRock.LineBot.TemplateActionBase>();
        //                actions.Add(new isRock.LineBot.UriAction() { label = "Go To Detail Page", uri = new Uri(prourl) });

        //                var Column = new isRock.LineBot.Column
        //                {
        //                    text = carouseltext,
        //                    title = productname,
        //                    thumbnailImageUrl = new Uri(creatorimg),
        //                    actions = actions
        //                };
        //                CarouselTemplate.columns.Add(Column);

        //            }
        //        }
        //        else if (productprice)
        //        {
        //            var pricelist = new List<LineProductViewModel>();
        //            //判斷遊戲產品價格
        //            switch (keyword)
        //            {
        //                case "$1~$5":
        //                    pricelist = result.Where(x => x.UnitPrice >= 1M && x.UnitPrice <= 5M).ToList();
        //                    break;
        //                case "$5~$10":
        //                    pricelist = result.Where(x => x.UnitPrice >= 5M && x.UnitPrice <= 10M).ToList();
        //                    break;
        //                case "$10~$20":
        //                    pricelist = result.Where(x => x.UnitPrice >= 10M && x.UnitPrice <= 20M).ToList();
        //                    break;
        //                case "$20 up":
        //                    pricelist = result.Where(x => x.UnitPrice >= 20M).ToList();
        //                    break;
        //                default:
        //                    pricelist = null;
        //                    break;
        //            }

        //            var bycat = pricelist.Select(x => new LineProductViewModel()
        //            {
        //                ProductId = x.ProductId,
        //                UnitPrice = x.UnitPrice,
        //                MemberName = x.MemberName,
        //                GameName = x.GameName,
        //                Server = x.Server,
        //                Level = x.Level,
        //                Position = x.Position,
        //                CreatorImg = x.CreatorImg
        //            })
        //                                .OrderBy(x => rnd.Next()).Take(5);

        //            foreach (var cat in bycat)
        //            {
        //                var creatorimg = cat.CreatorImg;
        //                var memberName = cat.MemberName;
        //                var price = cat.UnitPrice.ToString();
        //                var proId = cat.ProductId;
        //                var productname = cat.GameName;

        //                var prourl = string.Format("https://epal-frontstage.azurewebsites.net/ePals/Detail/{0}",
        //                    proId);

        //                var carouseltext = string.Format("{0} {1}${2}",
        //                            cat.MemberName,
        //                            Environment.NewLine,
        //                            cat.UnitPrice);

        //                var actions = new List<isRock.LineBot.TemplateActionBase>();
        //                actions.Add(new isRock.LineBot.UriAction() { label = "Go To Detail Page", uri = new Uri(prourl) });

        //                var Column = new isRock.LineBot.Column
        //                {
        //                    text = carouseltext,
        //                    title = productname,
        //                    thumbnailImageUrl = new Uri(creatorimg),
        //                    actions = actions
        //                };
        //                CarouselTemplate.columns.Add(Column);

        //            }
        //        }
        //        else if (server)
        //        {
        //            var bycat = result.Where(x => x.Server == keyword).Select(x => new LineProductViewModel()
        //            {
        //                ProductId = x.ProductId,
        //                UnitPrice = x.UnitPrice,
        //                MemberName = x.MemberName,
        //                GameName = x.GameName,
        //                Server = x.Server,
        //                Level = x.Level,
        //                Position = x.Position,
        //                CreatorImg = x.CreatorImg
        //            })
        //                                .OrderBy(x => rnd.Next()).Take(5);

        //            foreach (var cat in bycat)
        //            {
        //                var creatorimg = cat.CreatorImg;
        //                var memberName = cat.MemberName;
        //                var price = cat.UnitPrice.ToString();
        //                var proId = cat.ProductId;
        //                var productname = cat.GameName;

        //                var prourl = string.Format("https://epal-frontstage.azurewebsites.net/ePals/Detail/{0}",
        //                    proId);

        //                var carouseltext = string.Format("{0} {1}${2}",
        //                            cat.MemberName,
        //                            Environment.NewLine,
        //                            cat.UnitPrice);

        //                var actions = new List<isRock.LineBot.TemplateActionBase>();
        //                actions.Add(new isRock.LineBot.UriAction() { label = "Go To Detail Page", uri = new Uri(prourl) });

        //                var Column = new isRock.LineBot.Column
        //                {
        //                    text = carouseltext,
        //                    title = productname,
        //                    thumbnailImageUrl = new Uri(creatorimg),
        //                    actions = actions
        //                };
        //                CarouselTemplate.columns.Add(Column);

        //            }
        //        }
        //        else
        //        {
        //            ReplyMessage(token, "Don't enter text directly. Please see about us!");
        //            return false;
        //        }
        //        //Default = "找不到相關商品";
        //        //return Default;


        //    }
        //    catch (Exception ex)
        //    {
        //        ReplyMessage(token, "Error!");
        //        return false;
        //        //return Default;
        //    }


        //    ReplyMessage(token, CarouselTemplate);
        //    return true;
        //}






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