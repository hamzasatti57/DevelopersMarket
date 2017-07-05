namespace FypProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hamza6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        CartItemId = c.Int(nullable: false, identity: true),
                        CartId = c.String(nullable: false),
                        GraphicID = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CartItemId)
                .ForeignKey("dbo.Graphics", t => t.GraphicID, cascadeDelete: true)
                .Index(t => t.GraphicID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartItems", "GraphicID", "dbo.Graphics");
            DropIndex("dbo.CartItems", new[] { "GraphicID" });
            DropTable("dbo.CartItems");
        }
    }
}
