namespace Covid19CharitySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v22 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Donations", "User_Id", "dbo.Users");
            DropIndex("dbo.Donations", new[] { "User_Id" });
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Donation_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Note = c.String(),
                        User_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id1)
                .Index(t => t.User_Id1);
            
            AddColumn("dbo.Donations", "IsAssigned", c => c.Int(nullable: false));
            AddColumn("dbo.Donations", "PickLocation", c => c.String());
            AddColumn("dbo.Donations", "User_Id1", c => c.Int());
            CreateIndex("dbo.Donations", "User_Id1");
            AddForeignKey("dbo.Donations", "User_Id1", "dbo.Users", "Id");
            DropColumn("dbo.Donations", "amount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Donations", "amount", c => c.String());
            DropForeignKey("dbo.Donations", "User_Id1", "dbo.Users");
            DropForeignKey("dbo.Tasks", "User_Id1", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "User_Id1" });
            DropIndex("dbo.Donations", new[] { "User_Id1" });
            DropColumn("dbo.Donations", "User_Id1");
            DropColumn("dbo.Donations", "PickLocation");
            DropColumn("dbo.Donations", "IsAssigned");
            DropTable("dbo.Tasks");
            CreateIndex("dbo.Donations", "User_Id");
            AddForeignKey("dbo.Donations", "User_Id", "dbo.Users", "Id");
        }
    }
}
