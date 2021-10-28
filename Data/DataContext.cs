using System.Reflection.Emit;
using API_EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace API_EntityFramework.Data
{
    public class DataContext :DbContext
    {
        
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {}

        public DbSet<Client> client { get; set; }
        
    }
}