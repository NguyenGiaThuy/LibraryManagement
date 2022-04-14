using Microsoft.AspNetCore.Mvc;
using Server.Repositories;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreasurerController : Controller
    {
        private readonly ITreasurerRepository _repository;

        public TreasurerController(ITreasurerRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<LibUsersController>
        [HttpGet]
        public async Task<IActionResult> GetAllCallCardAsync()
        {
            
            var result = await _repository.GetCallCardAsync();
            return Ok(result);
        }

        // GET api/<LibUsersController>/5
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCallCardByIdAsync([FromRoute] int Id)
        {
            try
            {
                var result = await _repository.GetCallCardByIdAsync(Id);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        
    }
}
