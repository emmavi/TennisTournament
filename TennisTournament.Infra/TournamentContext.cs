using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Xml;
using TennisTournament.Domain;
using TennisTournament.Domain.Gender;

namespace TennisTournament.Infra
{
    public class TournamentContext : DbContext
    {
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Player> Players { get; set; }
        public TournamentContext(DbContextOptions<TournamentContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tournament>().HasKey(b => b.Id);
            modelBuilder.Entity<Tournament>().Ignore(x => x.Players);
            modelBuilder.Entity<Tournament>()
                            .HasOne(b => b.Winner)
                            .WithMany(a => a.Tournaments)
                            .HasForeignKey(p => p.WinnerId);


            modelBuilder.Entity<Player>().HasKey(b => b.Id);
            modelBuilder.Entity<Player>().Ignore(x => x.GenderStrengths);
            modelBuilder.Entity<Player>()
                            .Property(e => e.Gender)
                            .HasConversion<int>();
        }
    }
}