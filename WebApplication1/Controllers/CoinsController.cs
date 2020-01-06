﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CoinsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Coins
        public ActionResult Index()
        {
            var coins = db.Coins.Include(c => c.Market);
            return View(coins.ToList());
        }

        // GET: Coins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coin coin = db.Coins.Find(id);
            if (coin == null)
            {
                return HttpNotFound();
            }
            return View(coin);
        }

        // GET: Coins/Create
        public ActionResult Create()
        {
            ViewBag.MarketId = new SelectList(db.Markets, "Id", "Name");
            return View();
        }

        // POST: Coins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,BaseAsset,QuoteAsset,LastPrice,Volumn24h,MarketId,CreateAt,UpdatedAt,Status")] Coin coin)
        {
            coin.Id = coin.BaseAsset + "_" + coin.QuoteAsset + "_" + coin.MarketId;
            coin.CreateAt = DateTime.Now;
            coin.UpdatedAt = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Coins.Add(coin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MarketId = new SelectList(db.Markets, "Id", "Name", coin.MarketId);
            return View(coin);
        }

    }
}
