using Microsoft.AspNetCore.Mvc;
using Server.Helpers.Exceptions;
using Server.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibBookAuditCardsController : ControllerBase
    {
        private readonly ILibBookAuditCardsRepository _bookAuditCardsRepository;

        public LibBookAuditCardsController(ILibBookAuditCardsRepository bookAuditCardsRepository)
        {
            _bookAuditCardsRepository = bookAuditCardsRepository;
        }

        // GET: api/<LibBookAuditCardsController>
        [HttpGet]
        public async Task<IActionResult> GetBookAuditCardsAsync()
        {
            var result = await _bookAuditCardsRepository.GetBookAuditCardsAsync();
            return Ok(result);
        }

        // GET api/<LibBookAuditCardsController>/5
        [HttpGet("{bookAuditCardId}")]
        public async Task<IActionResult> GetBookAuditCardByIdAsync([FromRoute] string bookAuditCardId)
        {
            try
            {
                var result = await _bookAuditCardsRepository.GetBookAuditCardByIdAsync(bookAuditCardId);
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

        // GET api/<LibBookAuditCardsController>/book/5
        [HttpGet("book/{bookId}")]
        public async Task<IActionResult> GetBookAuditCardByBookIdAsync([FromRoute] string bookId)
        {
            try
            {
                var result = await _bookAuditCardsRepository.GetBookAuditCardByBookIdAsync(bookId);
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
