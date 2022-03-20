using Labb_4___API;
using Labb_4___API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Labb_4___API_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HobbyController : Controller
    {
        private IRepo<Hobby> hobbies;
        HobbyController(IRepo<Hobby> hobbies)
        {
            this.hobbies = hobbies;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                return Ok(await hobbies.GetAllAsync());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when retrieving all hobbies from the database.");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleAsync(int id)
        {
            try
            {
                var hobbySearch = await hobbies.GetSingleAsync(id);
                if (hobbySearch != null)
                {
                    return Ok(hobbySearch);
                }
                return NotFound("Hobby with this ID could not be found in the database.");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when retrieving hobby with specific ID from the database.");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Hobby>> AddAsync(Hobby newHobby)
        {
            try
            {
                if (newHobby != null)
                {
                    var hobbyAdded = await hobbies.AddAsync(newHobby);
                    return Created("Hobby was added to the database.", hobbyAdded);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to add hobby to database");
            }
        }
        [HttpDelete("{id")]
        public async Task<ActionResult<Hobby>> DeleteAsync(int id)
        {
            try
            {
                var findHobby = await hobbies.GetSingleAsync(id);
                if (findHobby != null)
                {
                    return await hobbies.DeleteAsync(findHobby.ID);
                }
                return NotFound($"Hobby with ID {id} could not be found.");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to delete hobby from database");
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Hobby>> UpdateAsync(int id, Hobby upDog)
        {
            try
            {
                if (id != upDog.ID)
                {
                    return BadRequest("Hobby ID doesn´t match.");
                }
                var tempProd = await hobbies.GetSingleAsync(id);
                if (tempProd == null)
                {
                    return NotFound($"Hobby with ID {id} could not be found.");
                }
                return await hobbies.UpdateAsync(tempProd);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when updating database...");
            }
        }
    }
}
