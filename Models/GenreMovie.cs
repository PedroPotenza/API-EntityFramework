using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_EntityFramework.Models
{
    public class GenreMovie
    {
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}