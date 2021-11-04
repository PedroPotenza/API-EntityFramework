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
        public ICollection<GenreMovie> Movies { get; set; }
        //reference: https://henriquesd.medium.com/entity-framework-core-5-0-many-to-many-relationships-52c6c8b07b6e
        
        //IDEA: maybe a bool IsSubGenre? 
        //IDEA: and a GenreFatherFK? 
    }
}