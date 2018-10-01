namespace Archery.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class BackOffice : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bows",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Tournaments",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 50),
                    Location = c.String(nullable: false, maxLength: 250),
                    StartDate = c.DateTime(nullable: false),
                    EndDate = c.DateTime(nullable: false),
                    ArcherCount = c.Int(nullable: false),
                    Price = c.Decimal(precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Shooters",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    TournamentID = c.Int(nullable: false),
                    WeaponID = c.Int(nullable: false),
                    ArcherID = c.Int(nullable: false),
                    Departure = c.DateTime(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Archers", t => t.ArcherID, cascadeDelete: false)
                .ForeignKey("dbo.Bows", t => t.WeaponID, cascadeDelete: false)
                .ForeignKey("dbo.Tournaments", t => t.TournamentID, cascadeDelete: false)
                .Index(t => t.TournamentID)
                .Index(t => t.WeaponID)
                .Index(t => t.ArcherID);

            CreateTable(
                "dbo.TournamentBows",
                c => new
                {
                    Tournament_ID = c.Int(nullable: false),
                    Bow_ID = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Tournament_ID, t.Bow_ID })
                .ForeignKey("dbo.Tournaments", t => t.Tournament_ID, cascadeDelete: false)
                .ForeignKey("dbo.Bows", t => t.Bow_ID, cascadeDelete: false)
                .Index(t => t.Tournament_ID)
                .Index(t => t.Bow_ID);
        }

        public override void Down()
        {
            DropForeignKey("dbo.TournamentBows", "Bow_ID", "dbo.Bows");
            DropForeignKey("dbo.TournamentBows", "Tournament_ID", "dbo.Tournaments");
            DropForeignKey("dbo.Shooters", "TournamentID", "dbo.Tournaments");
            DropForeignKey("dbo.Shooters", "WeaponID", "dbo.Bows");
            DropForeignKey("dbo.Shooters", "ArcherID", "dbo.Archers");
            DropIndex("dbo.TournamentBows", new[] { "Bow_ID" });
            DropIndex("dbo.TournamentBows", new[] { "Tournament_ID" });
            DropIndex("dbo.Shooters", new[] { "ArcherID" });
            DropIndex("dbo.Shooters", new[] { "WeaponID" });
            DropIndex("dbo.Shooters", new[] { "TournamentID" });
            DropTable("dbo.TournamentBows");
            DropTable("dbo.Shooters");
            DropTable("dbo.Tournaments");
            DropTable("dbo.Bows");
        }
    }
}