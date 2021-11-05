using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_EntityFramework.Data;
using API_EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_EntityFramework.Controllers
{
    //OK: GET All
    //OK: GET One
    //OK: POST 
    //OK: PUT 
    //OK: DELETE 

    [Controller]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private DataContext dataContext;

        public MovieController(DataContext context)
        {
            this.dataContext = context;
        }

        [HttpPost("")]
        public async Task<ActionResult> RegisterMovie([FromBody] Movie movie)
        {
            //ROUTES FOR MANY TO MANY 
            //https://softdevpractice.com/blog/many-to-many-ef-core/
            
            dataContext.movie.Add(movie);
            await dataContext.SaveChangesAsync();
            return Created("Object \"Movie\" created!", movie);

        } 

        [HttpGet("")]
        public async Task<ActionResult> ShowMovies()
        {
            var data = await dataContext.movie.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{Id}")]
        public Movie FindMovie(int Id)
        {
            Movie movie = dataContext.movie.Find(Id);
            return movie;
        }

        [HttpGet("{LookingMovieId}/genres/{showIds}")]
        public async Task<ActionResult> FindAllGenresOfMovie(int LookingMovieId, bool showIds)
        {

            //get specific movie with all genres
            var movieIncludingGenres = await dataContext.movie.Include(Movie => Movie.Genres).ThenInclude(row => row.Genre).FirstAsync(movie => movie.MovieId == LookingMovieId);
            
            //get all genres of movie
            var movieGenres = movieIncludingGenres.Genres.Select(row => row.Genre);
            
            List<int> GenreIds = new List<int>();
            List<string> GenreNames = new List<string>();
            
            foreach(Genre genre in movieGenres)
            {
                GenreIds.Add(genre.GenreId);
                GenreNames.Add(genre.Name);
            }
                
            if(showIds)
                return Ok(GenreIds);
            else
                return Ok(GenreNames);

        }

        [HttpPut("")]
        public async Task<ActionResult> UpdateMovie([FromBody] Movie movie)
        {
            dataContext.movie.Update(movie);
            await dataContext.SaveChangesAsync();
            return Ok("Update success!");
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteMovie(int Id)
        {
            Movie movie = FindMovie(Id);
            if(movie == null)
            {
                return NotFound();
            }
            else
            {
                string name = movie.Name;
                dataContext.movie.Remove(movie);
                await dataContext.SaveChangesAsync();
                return Ok("Movie \""+ name +"\" deleted!");
            }
        }
    }
}