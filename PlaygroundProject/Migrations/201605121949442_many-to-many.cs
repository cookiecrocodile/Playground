namespace PlaygroundProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class manytomany : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pawns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Hp = c.Int(nullable: false),
                        Type = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Type, unique: true);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Rank_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerId)
                .ForeignKey("dbo.Ranks", t => t.Rank_Id, cascadeDelete: true)
                .Index(t => t.Rank_Id);
            
            CreateTable(
                "dbo.Ranks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RankName = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.RankName, unique: true);
            
            CreateTable(
                "dbo.PlayerPawns",
                c => new
                    {
                        Player_PlayerId = c.Int(nullable: false),
                        Pawn_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Player_PlayerId, t.Pawn_Id })
                .ForeignKey("dbo.Players", t => t.Player_PlayerId, cascadeDelete: true)
                .ForeignKey("dbo.Pawns", t => t.Pawn_Id, cascadeDelete: true)
                .Index(t => t.Player_PlayerId)
                .Index(t => t.Pawn_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "Rank_Id", "dbo.Ranks");
            DropForeignKey("dbo.PlayerPawns", "Pawn_Id", "dbo.Pawns");
            DropForeignKey("dbo.PlayerPawns", "Player_PlayerId", "dbo.Players");
            DropIndex("dbo.PlayerPawns", new[] { "Pawn_Id" });
            DropIndex("dbo.PlayerPawns", new[] { "Player_PlayerId" });
            DropIndex("dbo.Ranks", new[] { "RankName" });
            DropIndex("dbo.Players", new[] { "Rank_Id" });
            DropIndex("dbo.Pawns", new[] { "Type" });
            DropTable("dbo.PlayerPawns");
            DropTable("dbo.Ranks");
            DropTable("dbo.Players");
            DropTable("dbo.Pawns");
        }
    }
}
