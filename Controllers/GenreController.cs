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
    public class GenreController : ControllerBase
    {
        private DataContext dataContext;

        public GenreController(DataContext context)
        {
            this.dataContext = context;
        }

        [HttpGet("")]
        public async Task<ActionResult> ShowGenre()
        {
            var genres = await dataContext.genre.ToListAsync();
            return Ok(genres);
        }

        [HttpGet("{Id}")]
        public Genre FindGenre(int Id)
        {
            Genre genre = dataContext.genre.Find(Id);
            return genre;
        }

        [HttpPost("")]
        public async Task<ActionResult> RegisterGenre([FromBody] Genre genre)
        {
            dataContext.genre.Add(genre);
            await dataContext.SaveChangesAsync();
            return Ok(genre);
        }

        [HttpPut("")]
        public async Task<ActionResult> UpdateGenre([FromBody] Genre genre)
        {
            dataContext.genre.Update(genre);
            await dataContext.SaveChangesAsync();
            return Ok(genre);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteGenre(int id)
        {
            Genre genre = FindGenre(id);
            if(genre == null)
            {
                return NotFound();
            }
            else
            {
                string name = genre.Name;
                dataContext.genre.Remove(genre);
                await dataContext.SaveChangesAsync();
                return Ok("Genre \"" + name + "\" Deleted!");
            }
        }

    }
}