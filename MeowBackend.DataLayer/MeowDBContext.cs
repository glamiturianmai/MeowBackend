using Microsoft.EntityFrameworkCore;
using MeowBackend.Core.Dtos;
namespace MeowBackend.DataLayer
{
    public class MeowDBContext: DbContext
    {
        public DbSet<CatDto> Cats { get; set; }
        public DbSet<PersonDto> Persons { get; set; }

        public MeowDBContext(DbContextOptions<MeowDBContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<CatDto>()
                .HasOne(d => d.Owner)
                .WithMany(u => u.Cats);
        }
    }
}
