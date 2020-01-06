namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDatebase : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Coins", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Coins", "BaseAsset", c => c.String(nullable: false));
            AlterColumn("dbo.Coins", "QuoteAsset", c => c.String(nullable: false));
            AlterColumn("dbo.Coins", "CreateAt", c => c.DateTime());
            AlterColumn("dbo.Coins", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.Markets", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Markets", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Markets", "CreateAt", c => c.DateTime());
            AlterColumn("dbo.Markets", "UpdatedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Markets", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Markets", "CreateAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Markets", "Description", c => c.String());
            AlterColumn("dbo.Markets", "Name", c => c.String());
            AlterColumn("dbo.Coins", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Coins", "CreateAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Coins", "QuoteAsset", c => c.String());
            AlterColumn("dbo.Coins", "BaseAsset", c => c.String());
            AlterColumn("dbo.Coins", "Name", c => c.String());
        }
    }
}
