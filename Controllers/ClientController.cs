using System.Threading.Tasks;
using API_EntityFramework.Data;
using API_EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_EntityFramework.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class ClientController :ControllerBase
    {

        private DataContext dc;

        public ClientController(DataContext context)
        {
            this.dc = context; //aula 12 isso aê
        }

        [HttpPost("api")]
        public async Task<ActionResult> cadastrar([FromBody] Client c)
        {
            dc.client.Add(c);
            await dc.SaveChangesAsync();

            return Created("Objeto Cliente", c );
        }

        [HttpGet("api")]
        public async Task<ActionResult> ShowClients()
        {
            
            var dados = await dc.client.ToListAsync();
            return Ok(dados);

        }

        [HttpGet("api/{id}")]
        public Client FindClient(int id)
        {
            Client client = dc.client.Find(id);
            return client;
        }

        [HttpPut("api")]
        public async Task<ActionResult> UpdateClient([FromBody] Client client)
        {
            dc.client.Update(client);
            await dc.SaveChangesAsync();
            return Ok(client);
        }

        [HttpDelete("api/{id}")]
        public async Task<ActionResult> DeleteClient(int id)
        {
            Client client = FindClient(id);

            if(client == null)
            {
                return NotFound();
            } 
            else
            {
                dc.client.Remove(client);
                await dc.SaveChangesAsync();
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