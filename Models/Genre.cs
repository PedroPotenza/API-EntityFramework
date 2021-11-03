using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_EntityFramework.Models
{
    public class Genre
    {
        // public Genre()
        // {
        //     this.Movies = new HashSet<Movie>();
        // }

        [Key]
        public int GenreId { get; set; }
        public string Name { get; set; }
        //[ForeignKey("MovieFK")]
        public IList<GenreMovie> GenreMovie { get; set; }
        
        //IDEA: maybe a bool IsSubGenre? 
        //IDEA: and a GenreFatherFK? 
    }
}