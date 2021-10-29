using System.Reflection.Emit;
using API_EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace API_EntityFramework.Data
{
    public class DataContext :DbContext
    {
        
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {} //EXPLICATION: instance of DataConext with some default options (?)

        //EXPLICATION: Set what's gonna transforme to tables on DB
        public DbSet<Client> client { get; set; } 
        
    }
}