namespace PlaygroundProject.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PlaygroundProject.Models.GameContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "PlaygroundProject.Models.GameContext";
        }

        protected override void Seed(PlaygroundProject.Models.GameContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var p1 = new Models.Pawn() { Hp = 4, Type = "Tavernkeeper" };
            var p2 = new Models.Pawn() { Hp = 7, Type = "Hunter" };


            //lambda-uttrycket säger vilken property som ska användas
            //för att avgöra om objektet redan finns i databasen
            context.Pawns.AddOrUpdate(p => p.Type, new Models.Pawn()
            {
                Hp = 5,
                Type = "Farmer"
            });

            context.Pawns.AddOrUpdate(p => p.Type, new Models.Pawn()
            {
                Hp = 6,
                Type = "Blacksmith"
            });

            context.Pawns.AddOrUpdate(p => p.Type, p1);
            context.Pawns.AddOrUpdate(p => p.Type, p2);

            context.Ranks.AddOrUpdate(r => r.RankName, new Models.Rank()
            {
                RankName = "Nobody"
            });

            context.Ranks.AddOrUpdate(r => r.RankName, new Models.Rank()
            {
                RankName = "Upstart"
            });


        }
    }
}
