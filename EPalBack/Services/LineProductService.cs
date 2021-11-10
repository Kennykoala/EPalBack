using EPalBack.DataModels;
using EPalBack.Repositories;
using EPalBack.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPalBack.Services
{
    public class LineProductService
    {

        private readonly Repository<Product> _repository;
        //private readonly isRock.LineBot.LineWebHookControllerBase _linewebhook;

        public LineProductService(Repository<Product> repository)
        {
            _repository = repository;
            //_linewebhook = new isRock.LineBot.LineWebHookControllerBase();
        }

        public IEnumerable<LineProductViewModel> GetAllProduct()
        {
            return _repository.GetAll().Select(x => new LineProductViewModel()
            {
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                MemberName = x.Creator.MemberName,
                GameName = x.GameCategory.GameName,
                Server = x.ProductServers.FirstOrDefault(y => y.ProductId == x.ProductId) == null ? null : x.ProductServers.First(y => y.ProductId == x.ProductId).Server.ServerName,
                Level = x.Rank.RankName,
                Position = x.ProductPositions.FirstOrDefault(y => y.ProductId == x.ProductId) == null ? null : x.ProductPositions.First(y => y.ProductId == x.ProductId).Position.PositionName,
                CreatorImg = x.CreatorImg,
                gender = x.Creator.Gender
                //gender = (genderenum)x.Creator.Gender
            }).ToList();
        }



        //public bool GetResult(string keyword, string token, string UserId)
        //{
        //    //string Default = "Sorry, keyword is wrong!";
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
        //        var result = GetAllProduct();

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
        //            _linewebhook.ReplyMessage(token, "Don't enter text directly. Please see about us!");
        //            return false;
        //        }
        //        //Default = "找不到相關商品";
        //        //return Default;


        //    }
        //    catch (Exception ex)
        //    {
        //        _linewebhook.ReplyMessage(token, "Error!");
        //        return false;
        //    }


        //    _linewebhook.ReplyMessage(token, CarouselTemplate);
        //    return true;

        //}

    }
}
