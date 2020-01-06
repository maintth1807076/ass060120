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
        public ActionResult Index(int? marketId, string keyWord)
        {
            var coins = db.Coins.Where(c => c.Status == 0);
            if (marketId != null)
            {
                coins = coins.Where(c => c.MarketId == marketId);
            }
            if (keyWord != null)
            {
                coins = coins.Where(c => c.Id.Contains(keyWord) || c.Name.Contains(keyWord)); 
            }
            
            ViewBag.MarketId = new SelectList(db.Markets, "Id", "Name");
            return View(coins.ToList());
        }
    }
}