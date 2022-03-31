using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibUsersController : ControllerBase
    {
        private readonly ILibUserRepository _repository;

        public LibUsersController(ILibUserRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<LibUsersController>
        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var result = await _repository.GetUsersAsync();
            return Ok(result);
        }

        // GET api/<LibUsersController>/5
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserByIdAsync([FromRoute] string userId)
        {
            try
            {
                var result = await _repository.GetUserByIdAsync(userId);
                return Ok(result);
            } 
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/<LibUsersController>
        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] LibUser user)
        {
            try 
            {
                var result = await _repository.CreateUserAsync(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<LibUsersController>/5
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUserAsync([FromRoute] string userId, [FromBody] LibUser user)
        {
            try
            {
                var result = await _repository.UpdateUserAsync(userId, user);
                return Ok(result);
            }
            catch(ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<LibUsersController>/5
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUserAsync([FromRoute] string userId)
        {
            try
            {
                var result = await _repository.DeleteUserAsync(userId);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
