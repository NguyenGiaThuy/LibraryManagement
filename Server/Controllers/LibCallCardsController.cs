using Microsoft.AspNetCore.Mvc;
using Server.Helpers.Exceptions;
using Server.Models;
using Server.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibCallCardsController : ControllerBase
    {
        private readonly ILibCallCardsRepository _callCardsRepository;

        public LibCallCardsController(ILibCallCardsRepository callCardsRepository)
        {
            _callCardsRepository = callCardsRepository;
        }

        // GET: api/<LibCallCardsController>
        [HttpGet]
        public async Task<IActionResult> GetCallCardsAsync()
        {
            var result = await _callCardsRepository.GetCallCardsAsync();
            return Ok(result);
        }

        // GET api/<LibCallCardsController>/5
        [HttpGet("{callCardId}")]
        public async Task<IActionResult> GetCallCardByIdAsync([FromRoute] string callCardId)
        {
            try
            {
                var result = await _callCardsRepository.GetCallCardByIdAsync(callCardId);
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

        // GET api/<LibCallCardsController>/book/5
        [HttpGet("book/{bookId}")]
        public async Task<IActionResult> GetCallCardByBookIdAsync([FromRoute] string bookId)
        {
            try
            {
                var result = await _callCardsRepository.GetCallCardByBookIdAsync(bookId);
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

        // POST api/<LibCallCardsController>
        [HttpPost]
        public async Task<IActionResult> CreateCallCardAsync([FromBody] LibCallCard callCard)
        {
            try
            {
                var result = await _callCardsRepository.CreateCallCardAsync(callCard);
                return Ok(result);
            }
            catch (ExpiredMembershipException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (UnavailableBookException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (DueCallCardException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PATCH api/<LibCallCardsController>/5
        [HttpPatch("{callCardId}/{status}")]
        public async Task<IActionResult> UpdateCallCardStatusAsync([FromRoute] string callCardId, [FromRoute] int status)
        {
            try
            {
                var result = await _callCardsRepository.UpdateCallCardStatusAsync(callCardId, status);
                return Ok(result);
            }
            catch (NonExistenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
