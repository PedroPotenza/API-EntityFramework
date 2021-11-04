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
        public DbSet<Movie> movie { get; set; }

        public DbSet<GenreMovie> genreMovies { get; set; }

        public DbSet<Contract> contract { get; set; }
        public DbSet<History> history { get; set; }
        public DbSet<HistoryRegister> historyRegister { get; set; }

        // public override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<GenreMovie>()
        //         .HasOne(g => g.Genre)
        //         .WithMany(gm => gm.GenreMovie)
        //         .HasForeignKey(gi => gi.GenreId);

        //     modelBuilder.Entity<GenreMovie>()
        //         .HasOne(g => g.Movie)
        //         .WithMany(gm => gm.GenreMovie)
        //         .HasForeignKey(gi => gi.MovieId);
        // }
        // reference: https://www.youtube.com/watch?v=Qh2hgIc90y0

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<GenreMovie>().HasKey(i => new {i.GenreId, i.MovieId });
            
        }
    }
}