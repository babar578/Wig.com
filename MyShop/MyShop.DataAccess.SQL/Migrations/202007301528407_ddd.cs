namespace MyShop.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ddd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Basketitems",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        basketId = c.String(),
                        ProductId = c.String(),
                        Quntity = c.Int(nullable: false),
                        Createdt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Baskets",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Createdt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Baskets");
            DropTable("dbo.Basketitems");
        }
    }
}
