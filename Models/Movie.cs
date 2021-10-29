using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_EntityFramework.Models
{
    public class Movie
    {
        // public enum MovieRating
        // {
        //     G = 0,
        //     PG,
        //     PG13,
        //     R,
        //     NC17
        // }

        public Movie()
        {
            this.Genres = new HashSet<Genre>();
        }

        [Key]
        public int MovieId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Plot { get; set; }
        public int year { get; set; }
        public string Director { get; set; }
        // public MovieRating Rating { get; set; }
        [ForeignKey("MovieFK")]
        public virtual ICollection<Genre> Genres { get; set; }
        
    }
}