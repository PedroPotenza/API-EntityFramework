using System.ComponentModel.DataAnnotations;

namespace API_EntityFramework.Models
{
    public class Plan
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public string MaxQuality { get; set; }
        public int MaxSimultaneousDevices { get; set; }
        [Required]
        public double LoyaltyFine { get; set; } 
        [Required]
        public int LoyaltyFineTime { get; set; } 
        public int MaxMovies { get; set; }
        public bool Download { get; set; }
    }
}