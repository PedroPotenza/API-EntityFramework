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
        public DbSet<GenreMovie> GenreMovie { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GenreMovie>().HasKey(gm => new { gm.GenreId, gm.MovieId });
        }
        
    }
}