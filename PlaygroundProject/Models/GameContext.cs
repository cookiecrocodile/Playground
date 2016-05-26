using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Web;

namespace PlaygroundProject.Models
{
    public class GameContext : DbContext
    {
        public GameContext() : base() { }

        public DbSet<Player> Players { get; set; }

        public DbSet<Pawn> Pawns { get; set; }

        public DbSet<Rank> Ranks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasMany(p => p.Pawns);

            modelBuilder.Entity<Player>()
                .HasRequired(p => p.Rank);

            modelBuilder.Entity<Pawn>().Property(p => p.Hp)
                .HasColumnType("int");

            modelBuilder.Entity<Pawn>().Property(p => p.Type)
                .HasColumnType("nvarchar")
                .HasMaxLength(20);

            modelBuilder.Entity<Rank>().Property(r => r.RankName)
                .HasColumnType("nvarchar")
                .HasMaxLength(15);

            



            base.OnModelCreating(modelBuilder);
        }
    }
}