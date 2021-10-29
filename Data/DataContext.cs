using System.Reflection.Emit;
using API_EntityFramework.Models;
using Microsoft.EntityFrameworkCore;


namespace API_EntityFramework.Data
{
    public class DataContext : DbContext
    {
        
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {} //EXPLICATION: instance of DataConext with some default options (?)

        //EXPLICATION: Set what's gonna transforme to tables on DB
        public DbSet<Client> client { get; set; } 
        public DbSet<Plan> plan { get; set; } 
        public DbSet<Genre> genre { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Genre>()
                        .HasMany<Movie>(m => m.Movies)
                        .WithMany(g => g.Genres)
                        .Map(gm =>
                                {
                                    gm.MapLeftKey("GenreRefId");
                                    gm.MapRightKey("MovieRefId");
                                    gm.ToTable("GenreMovie");
                                });

        }
        
    }
}