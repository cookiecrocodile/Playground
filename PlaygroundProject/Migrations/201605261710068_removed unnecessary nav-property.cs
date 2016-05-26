namespace PlaygroundProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedunnecessarynavproperty : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PlayerPawns", "Player_PlayerId", "dbo.Players");
            DropForeignKey("dbo.PlayerPawns", "Pawn_Id", "dbo.Pawns");
            DropIndex("dbo.PlayerPawns", new[] { "Player_PlayerId" });
            DropIndex("dbo.PlayerPawns", new[] { "Pawn_Id" });
            AddColumn("dbo.Pawns", "Player_PlayerId", c => c.Int());
            CreateIndex("dbo.Pawns", "Player_PlayerId");
            AddForeignKey("dbo.Pawns", "Player_PlayerId", "dbo.Players", "PlayerId");
            DropTable("dbo.PlayerPawns");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PlayerPawns",
                c => new
                    {
                        Player_PlayerId = c.Int(nullable: false),
                        Pawn_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Player_PlayerId, t.Pawn_Id });
            
            DropForeignKey("dbo.Pawns", "Player_PlayerId", "dbo.Players");
            DropIndex("dbo.Pawns", new[] { "Player_PlayerId" });
            DropColumn("dbo.Pawns", "Player_PlayerId");
            CreateIndex("dbo.PlayerPawns", "Pawn_Id");
            CreateIndex("dbo.PlayerPawns", "Player_PlayerId");
            AddForeignKey("dbo.PlayerPawns", "Pawn_Id", "dbo.Pawns", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PlayerPawns", "Player_PlayerId", "dbo.Players", "PlayerId", cascadeDelete: true);
        }
    }
}
