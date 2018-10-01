namespace Archery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UniqueEmail2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Administrators", "Mail");
            DropIndex("dbo.Archers", "Mail");
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Archers", "Mail", unique: true, name: "Mail");
            CreateIndex("dbo.Administrators", "Mail", unique: true, name: "Mail");
        }
    }
}
