namespace FypProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hamza : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        DeveloperID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        Company = c.String(),
                        Location = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Description = c.String(),
                        Website = c.String(),
                        ImageUrl = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.DeveloperID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Profiles", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Profiles", new[] { "User_Id" });
            DropTable("dbo.Profiles");
        }
    }
}
