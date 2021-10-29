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
    public class PlanController : ControllerBase
    {
        private DataContext dataContext;

        public PlanController(DataContext context)
        {
            this.dataContext = context;
        }

        [HttpGet("")]
        public async Task<ActionResult> ShowPlans(){

            var plans = await dataContext.plan.ToListAsync();
            return Ok(plans);

        }
        
        [HttpGet("{Id}")]
        public Plan FindPlan(int Id)
        {
            Plan plan = dataContext.plan.Find(Id);
            return plan;
        }

        [HttpGet("name/{Name}")]
        public async Task<ActionResult> FindPlanByName(string Name)
        {
            Plan plan = new Plan();
            
            plan = await dataContext.plan.FirstOrDefaultAsync(x => x.Name == Name);
                
            return Ok(plan);
            
        }
        
        [HttpPost("")]
        public async Task<ActionResult> RegisterPlan([FromBody] Plan plan)
        {
            dataContext.plan.Add(plan);
            await dataContext.SaveChangesAsync();

            return Created("Objeto Plan", plan );
        }

        [HttpPut("")]
        public async Task<ActionResult> UpdatePlan([FromBody] Plan plan)
        {
            dataContext.plan.Update(plan);
            await dataContext.SaveChangesAsync();
            return Ok(plan);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeletePlan(int Id)
        {
            Plan plan = FindPlan(Id);
            
            if(plan == null)
            {
                return NotFound();
            } 
            else
            {
                dataContext.plan.Remove(plan);
                await dataContext.SaveChangesAsync();
                return Ok();
            }
        }
    }
}