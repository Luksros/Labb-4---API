using Labb_4___API;
using Labb_4___API.Models;
using Labb_4___API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Labb_4___API_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebLinkController : Controller
    {
        private IRepo<WebLink> weblinks;
        WebLinkController(IRepo<WebLink> weblinks)
        {
            this.weblinks = weblinks;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                return Ok(await weblinks.GetAllAsync());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when retrieving all weblinks from the database.");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleAsync(int id)
        {
            try
            {
                var linkSearch = await weblinks.GetSingleAsync(id);
                if (linkSearch != null)
                {
                    return Ok(linkSearch);
                }
                return NotFound("Hobby with this ID could not be found in the database.");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when retrieving weblink with specific ID from the database.");
            }
        }
        [HttpPost]
        public async Task<ActionResult<WebLink>> AddAsync(WebLink newWebLink)
        {
            try
            {
                if (newWebLink != null)
                {
                    var linkAdded = await weblinks.AddAsync(newWebLink);
                    return Created("weblink was added to the database.", linkAdded);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to add weblink to database");
            }
        }
        [HttpDelete("{id")]
        public async Task<ActionResult<WebLink>> DeleteAsync(int id)
        {
            try
            {
                var findLink = await weblinks.GetSingleAsync(id);
                if (findLink != null)
                {
                    return await weblinks.DeleteAsync(findLink.ID);
                }
                return NotFound($"Weblink with ID {id} could not be found.");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to delete weblink from database");
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<WebLink>> UpdateAsync(int id, Hobby upDog)
        {
            try
            {
                if (id != upDog.ID)
                {
                    return BadRequest("Weblink ID doesn´t match.");
                }
                var tempProd = await weblinks.GetSingleAsync(id);
                if (tempProd == null)
                {
                    return NotFound($"Weblink with ID {id} could not be found.");
                }
                return await weblinks.UpdateAsync(tempProd);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when updating database...");
            }
        }
    }
}
