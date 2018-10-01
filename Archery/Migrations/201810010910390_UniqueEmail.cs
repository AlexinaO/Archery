namespace Archery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UniqueEmail : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Administrators", "Mail", unique: true, name: "Mail");
            CreateIndex("dbo.Archers", "Mail", unique: true, name: "Mail");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Archers", "Mail");
            DropIndex("dbo.Administrators", "Mail");
        }
    }
}
