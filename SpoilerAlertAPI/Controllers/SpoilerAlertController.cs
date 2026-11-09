using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpoilerAlertAPI.Models;
using System.Reflection;

namespace SpoilerAlertAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpoilerAlertController : ControllerBase
    {

        // Constructor
        public SpoilerAlertController() { 
            // Initialize

        }

        [HttpGet]                                       // FUNCTION NAME DOESNT MATTER
        public async Task<ActionResult<IEnumerable<SpoilerAlert>>> GetAllMovies()
        {

            var movies = new List<SpoilerAlert> {
            new SpoilerAlert { Id = 1, Title = "Sample 1" },
            new SpoilerAlert { Id = 2, Title = "Sample 2" },
            new SpoilerAlert { Id = 3, Title = "Sample 3" }
            };

            return Ok(movies);
        }

    }
}
