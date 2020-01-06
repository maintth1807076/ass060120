namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Coins",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        BaseAsset = c.String(),
                        QuoteAsset = c.String(),
                        LastPrice = c.Double(nullable: false),
                        Volumn24h = c.Double(nullable: false),
                        MarketId = c.Int(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Markets", t => t.MarketId, cascadeDelete: true)
                .Index(t => t.MarketId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Coins", "MarketId", "dbo.Markets");
            DropIndex("dbo.Coins", new[] { "MarketId" });
            DropTable("dbo.Coins");
        }
    }
}
