namespace Covid19CharitySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "IsActive", c => c.Int(nullable: false));
            AddColumn("dbo.Tasks", "CreatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "CreatedAt");
            DropColumn("dbo.Tasks", "IsActive");
        }
    }
}
