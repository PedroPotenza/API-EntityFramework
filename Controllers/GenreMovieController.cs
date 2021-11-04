using System.Threading.Tasks;
using API_EntityFramework.Data;
using API_EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_EntityFramework.Controllers
{
    //MISS: GET All
    //MISS: GET One
    //MISS: POST 
    //MISS: PUT 
    //MISS: DELETE 

    [Controller]
    [Route("[controller]")]
    public class GenreMovieController : ControllerBase
    {
        private DataContext dataContext;

        public GenreMovieController(DataContext context)
        {
            this.dataContext = context;
        }

        [HttpPost("")]
        public async Task<ActionResult> RegisterGenreMovie([FromBody] GenreMovie GenreMovie)
        {
            Genre genre = await dataContext.genre.FirstOrDefaultAsync(i => i.GenreId == GenreMovie.GenreId);
            Movie movie = await dataContext.movie.FirstOrDefaultAsync(i => i.MovieId == GenreMovie.MovieId);

            GenreMovie.Genre = genre;
            GenreMovie.Movie = movie;

            dataContext.genreMovies.Add(GenreMovie);
            await dataContext.SaveChangesAsync();
            return Ok("Genre \""+ GenreMovie.Genre.Name +"\" add to\""+ GenreMovie.Movie.Name +"\"!");

        }

        // public async Task<ActionResult> ShowAllGenreMovie()
        // {
        //     var list = await dataContext.genre
        // }
    }


}