using System.Threading.Tasks;
using API_EntityFramework.Data;
using API_EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_EntityFramework.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {

        private DataContext dataContext;

        public ClientController(DataContext context)
        {
            this.dataContext = context; //EXPLICATION: create a constructor specifying the data context who will be used
        }

        [HttpPost("")]
        public async Task<ActionResult> RegisterClient([FromBody] Client client)
        {
            dataContext.client.Add(client);
            await dataContext.SaveChangesAsync();

            return Created("Object Cliente created!", client );
        }

        [HttpGet("")]
        public async Task<ActionResult> ShowClients()
        {
            
            var data = await dataContext.client.ToListAsync();
            return Ok(data);

        }

        [HttpGet("{id}")]
        public Client FindDataContextClient(int id)
        {
            Client client = dataContext.client.Find(id);
            return client;
        }

        [HttpPut("")]
        public async Task<ActionResult> UpdateClient([FromBody] Client client)
        {
            dataContext.client.Update(client);
            await dataContext.SaveChangesAsync();
            return Ok(client);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClient(int id)
        {
            Client client = FindDataContextClient(id);

            if(client == null)
            {
                return NotFound();
            } 
            else
            {
                dataContext.client.Remove(client);
                await dataContext.SaveChangesAsync();
                return Ok();
            }


        }

        [HttpGet("HelloWorld")] //https://localhost:5001/client/helloworld
        public string oi()
        {
            return "Hello World";
        }

    }
}