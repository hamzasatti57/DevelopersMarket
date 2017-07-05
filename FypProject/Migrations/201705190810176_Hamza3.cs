namespace FypProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hamza3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "Product_GraphicID", "dbo.Graphics");
            DropIndex("dbo.Carts", new[] { "Product_GraphicID" });
            CreateTable(
                "dbo.AddCarts",
                c => new
                    {
                        AddCartId = c.Int(nullable: false, identity: true),
                        CartId = c.String(nullable: false),
                        GraphicID = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AddCartId)
                .ForeignKey("dbo.Graphics", t => t.GraphicID, cascadeDelete: true)
                .Index(t => t.GraphicID);
            
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartItemId = c.Int(nullable: false, identity: true),
                        CartId = c.String(nullable: false),
                        ID = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Product_GraphicID = c.Int(),
                    })
                .PrimaryKey(t => t.CartItemId);
            
            DropForeignKey("dbo.AddCarts", "GraphicID", "dbo.Graphics");
            DropIndex("dbo.AddCarts", new[] { "GraphicID" });
            DropTable("dbo.AddCarts");
            CreateIndex("dbo.Carts", "Product_GraphicID");
            AddForeignKey("dbo.Carts", "Product_GraphicID", "dbo.Graphics", "GraphicID");
        }
    }
}
