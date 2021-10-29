using System.Threading.Tasks;
using API_EntityFramework.Data;
using API_EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_EntityFramework.Controllers
{
    //OK: GET All
    //OK: GET One
    //MISS: POST 
    //MISS: PUT 
    //MISS: DELETE 

    // [Controller]
    // [Route("[controller]")]
    // public class GenreController : ControllerBase
    // {
    //     private DataContext dataContext;

    //     public GenreController(DataContext context)
    //     {
    //         this.dataContext = context;
    //     }

    //     [HttpGet("")]
    //     public async Task<ActionResult> ShowGenre()
    //     {
    //         var genres = await dataContext.genre.ToListAsync();
    //         return Ok(genres);
    //     }

    //     [HttpGet("{Id}")]
    //     public Genre FindGenre(int Id)
    //     {
    //         Genre genre = dataContext.genre.Find(Id);
    //         return genre;
    //     }
    // }
}