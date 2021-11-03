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
    public class MovieController :ControllerBase
    {
        private DataContext dataContext;

        public MovieController(DataContext context)
        {
            this.dataContext = context;
        }

        [HttpPost("")]
        public async Task<ActionResult> RegisterMovie([FromBody] Movie movie)
        {
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

        [HttpPut("")]
        public async Task<ActionResult> UpdateMovie([FromBody] Movie movie)
        {
            dataContext.movie.Update(movie);
            await dataContext.SaveChangesAsync();
            return Ok(movie);
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