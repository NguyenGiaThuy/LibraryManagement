using Microsoft.AspNetCore.Mvc;
using Server.Helpers.Exceptions;
using Server.Models;
using Server.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibFineCardsController : ControllerBase
    {
        private readonly ILibFineCardsRepository _fineCardsRepository;

        public LibFineCardsController(ILibFineCardsRepository fineCardsRepository)
        {
            _fineCardsRepository = fineCardsRepository;
        }

        // GET: api/<LibFineCardsController>
        [HttpGet]
        public async Task<IActionResult> GetFineCardsAsync()
        {
            var result = await _fineCardsRepository.GetFineCardsAsync();
            return Ok(result);
        }

        // GET api/<LibFineCardsController>/5
        [HttpGet("{fineCardId}")]
        public async Task<IActionResult> GetFineCardByIdAsync([FromRoute] string fineCardId)
        {
            try
            {
                var result = await _fineCardsRepository.GetFineCardByIdAsync(fineCardId);
                return Ok(result);
            }
            catch (NonExistenceException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET api/<LibFineCardsController>/callcard/5
        [HttpGet("callcard/{callCardId}")]
        public async Task<IActionResult> GetFineCardByCallCardIdAsync([FromRoute] string callCardId)
        {
            try
            {
                var result = await _fineCardsRepository.GetFineCardByCallCardIdAsync(callCardId);
                return Ok(result);
            }
            catch (NonExistenceException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/<LibFineCardsController>
        [HttpPost]
        public async Task<IActionResult> CreateFineCardAsync([FromBody] LibFineCard fineCard)
        {
            try
            {
                var result = await _fineCardsRepository.CreateFineCardAsync(fineCard);
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

        // PUT api/<LibFineCardsController>/5
        [HttpPut("{fineCardId}")]
        public async Task<IActionResult> UpdateFineCardArrearsAsync([FromRoute] string fineCardId)
        {
            try
            {
                var result = await _fineCardsRepository.UpdateFineCardArrearsAsync(fineCardId);
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

        // DELETE api/<LibFineCardsController>/5/
        [HttpDelete("{fineCardId}")]
        public async Task<IActionResult> CloseFineCardAsync([FromRoute] string fineCardId)
        {
            try
            {
                var result = await _fineCardsRepository.CloseFineCardAsync(fineCardId);
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
