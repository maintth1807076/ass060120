using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private MyDbContext db = new MyDbContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowCoin(int? marketId, string keyWord)
        {
            var coins = db.Coins.Where(c => c.Status == 0);
            if (marketId != null && marketId != 0)
            {
                ViewBag.CurrentMarketId = marketId;
                coins = coins.Where(c => c.MarketId == marketId);
            }
            if (keyWord != null)
            {
                ViewBag.CurrentKeyWord = keyWord;
                coins = coins.Where(c => c.Name.Contains(keyWord)); 
            }
            ViewBag.Markets = db.Markets;
            return View(coins.ToList());
        }
    }
}