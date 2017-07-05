namespace FypProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hamza2 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Scripts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Scripts",
                c => new
                    {
                        ScriptID = c.Int(nullable: false, identity: true),
                        ItemLevel = c.Int(nullable: false),
                        Category = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        File = c.String(),
                        ImageUrl = c.String(),
                        Layered = c.Int(nullable: false),
                        Layout = c.Int(nullable: false),
                        HighResolution = c.Int(nullable: false),
                        LiveDemo = c.String(),
                        VideoUrl = c.String(),
                        Tags = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Comment = c.String(),
                        License = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ScriptID);
            
        }
    }
}
