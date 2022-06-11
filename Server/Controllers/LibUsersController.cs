using Microsoft.AspNetCore.Mvc;
using Server.Helpers.Exceptions;
using Server.Models;
using Server.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibUsersController : ControllerBase
    {
        private readonly ILibUsersRepository _usersRepository;

        public LibUsersController(ILibUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        // GET: api/<LibUsersController>
        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            var result = await _usersRepository.GetUsersAsync();
            return Ok(result);
        }

        // GET: api/<LibUsersController>/5
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserByIdAsync([FromRoute] string userId)
        {
            try
            {
                var result = await _usersRepository.GetUserByIdAsync(userId);
                return Ok(result);
            }
            catch (NonExistenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<LibUsersController>/login
        [HttpPost("login")]
        public IActionResult GetUserByIdAndPassword(LibUser user)
        {
            try
            {
                var result = _usersRepository.GetUserByIdAndPassword(user.UserId, user.Password);
                return Ok(result);
            }
            catch (NonExistenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<LibUsersController>
        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] LibUser user)
        {
            try
            {
                var result = await _usersRepository.CreateUserAsync(user);
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
            if (userId != user.UserId) return BadRequest("User Id does not match");

            try
            {
                var result = await _usersRepository.UpdateUserAsync(user);
                return Ok(result);
            }
            catch (NonExistenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<LibUsersController>/5/disable
        [HttpPut("{userId}/disable")]
        public async Task<IActionResult> DisableUserAsync([FromRoute] string userId)
        {
            try
            {
                var result = await _usersRepository.DisableUserAsync(userId);
                return Ok(result);
            }
            catch (NonExistenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<LibUsersController>/5/enable
        [HttpPut("{userId}/enable")]
        public async Task<IActionResult> EnableUserAsync([FromRoute] string userId)
        {
            try
            {
                var result = await _usersRepository.EnableUserAsync(userId);
                return Ok(result);
            }
            catch (NonExistenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
