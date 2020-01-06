using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebApplication1.Models;

namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication1.Models.MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WebApplication1.Models.MyDbContext";
        }

        protected override void Seed(WebApplication1.Models.MyDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Markets.AddOrUpdate(
                m => m.Id,
                new Market() { Id = 1, Name = "Binance", Description = "Day la san Binance"},
                new Market() { Id = 2, Name = "Huobi", Description = "Day la san Huobi"},
                new Market() { Id = 3, Name = "Bitmex", Description = "Day la san Bitmex"}
                );
            context.Coins.AddOrUpdate(
                c => c.Id,
                new Coin() { Id = "BNB_BTC_1", Name = "BNB", BaseAsset = "BNB", QuoteAsset = "BTC", LastPrice = 55.84, Volumn24h = 12245.49, MarketId = 1},
                new Coin() { Id = "ETH_BTC_1", Name = "Ethereum", BaseAsset = "ETH", QuoteAsset = "BTC", LastPrice = 14.47, Volumn24h = 14244.47, MarketId = 1 },
                new Coin() { Id = "XRP_BTC_2", Name = "Ripple", BaseAsset = "XRP", QuoteAsset = "BTC", LastPrice = 141.11, Volumn24h = 141121.11, MarketId = 2 },
                new Coin() { Id = "BCH_BTC_2", Name = "Bitcoin Cash", BaseAsset = "BCH", QuoteAsset = "BTC", LastPrice = 235.85, Volumn24h = 234235.85, MarketId = 2 },
                new Coin() { Id = "DASH_BTC_3", Name = "Dash", BaseAsset = "DASH", QuoteAsset = "BTC", LastPrice = 2.79, Volumn24h = 11235.23, MarketId = 3 },
                new Coin() { Id = "DLT_BTC_3", Name = "Agrello", BaseAsset = "DLT", QuoteAsset = "BTC", LastPrice = 5.04, Volumn24h = 231342.35, MarketId = 3 }
                );
            var roleStore = new RoleStore<AppRole>(context);
            var roleManager = new RoleManager<AppRole>(roleStore);
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                
                var role = new AppRole("Admin");
                roleManager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "User"))
            {
                var role = new AppRole("User");
                roleManager.Create(role);
            }
            var store = new UserStore<AppUser>(context);
            var manager = new UserManager<AppUser>(store);
            if (!context.Users.Any(u => u.UserName == "adminne"))
            {
                var user = new AppUser() { UserName = "adminne" };
                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "Admin");
            }
            if (!context.Users.Any(u => u.UserName == "userne"))
            {
                var user = new AppUser() { UserName = "userne" };
                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "User");
            }
        }
    }
}
