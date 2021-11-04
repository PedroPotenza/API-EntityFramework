using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_EntityFramework.Models
{
    public class Movie
    {
        public enum MovieRating
        {
            G = 0,
            PG,
            PG13,
            R,
            NC17
        }

        [Key]
        public int MovieId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Plot { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public MovieRating Rating { get; set; }

        public ICollection<GenreMovie> Genres { get; set; }
        //reference: https://henriquesd.medium.com/entity-framework-core-5-0-many-to-many-relationships-52c6c8b07b6e
        
    }
}