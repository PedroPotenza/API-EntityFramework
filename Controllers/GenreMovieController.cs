using System.Collections.Generic;
using System.Linq;
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
            return Ok("Genre \"" + GenreMovie.Genre.Name + "\" add to\"" + GenreMovie.Movie.Name + "\"!");

        }

        [HttpGet("genre/{LookingGenreId}")]
        public async Task<ActionResult> FindAllMovieOfGenre(int LookingGenreId)
        {
            var MoviesWithSpecifcGenre = await dataContext.genreMovies.Where(gm => gm.GenreId == LookingGenreId).ToListAsync();
            
            List<int> MoviesListId = new List<int>();
            foreach(GenreMovie data in MoviesWithSpecifcGenre)
            {
                MoviesListId.Add(data.MovieId);
            }

            return Ok(MoviesListId);
        }

        [HttpGet("movie/{LookingMovieId}")]
        public async Task<ActionResult> FindAllGenreOfMovie(int LookingMovieId)
        {
            var GenresOfMovie = await dataContext.genreMovies.Where(gm => gm.MovieId == LookingMovieId).ToListAsync();

            List<int> GenreListId = new List<int>();
            foreach(GenreMovie data in GenresOfMovie)
            {
                GenreListId.Add(data.GenreId);
            }

            return Ok(GenreListId);
        }
    }


}