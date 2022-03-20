using Labb_4___API;
using Labb_4___API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Labb_4___API_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        private IRepo<Person> persons;
        PersonController(IRepo<Person> persons)
        {
            this.persons = persons;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                return Ok(await persons.GetAllAsync());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when retrieving all people from the database.");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleAsync(int id)
        {
            try
            {
                var personSearch = await persons.GetSingleAsync(id);
                if (personSearch != null)
                {
                    return Ok(personSearch);
                }
                return NotFound("Person with this ID could not be found in the database.");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when retrieving person with specific ID from the database.");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Person>> AddAsync(Person newPerson)
        {
            try
            {
                if (newPerson != null)
                {
                    var persAdded = await persons.AddAsync(newPerson);
                    return Created("Person was added to the database.",persAdded);
                }
                else
                {
                    return BadRequest();
                }        
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to add Person to database");
            }
        }
        [HttpDelete("{id")]
        public async Task<ActionResult<Person>> DeleteAsync(int id)
        {
            try
            {
                var findPerson = await persons.GetSingleAsync(id);
                if (findPerson != null)
                {
                    return await persons.DeleteAsync(findPerson.ID);
                }
                return NotFound($"Person with ID {id} could not be found.");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to delete Person from database");
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Person>> UpdateAsync(int id, Person upDog)
        {
            try
            {
                if (id != upDog.ID)
                {
                    return BadRequest("Person ID doesn´t match.");
                }
                var tempProd = await persons.GetSingleAsync(id);
                if (tempProd == null)
                {
                    return NotFound($"Person with ID {id} could not be found.");
                }
                return await persons.UpdateAsync(tempProd);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when updating database...");
            }
        }
    }
}
