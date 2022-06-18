using Microsoft.AspNetCore.Mvc;
using Server.Helpers.Exceptions;
using Server.Models;
using Server.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibBooksController : ControllerBase
    {
        private readonly ILibBooksRepository _booksRepository;

        public LibBooksController(ILibBooksRepository bookRepository)
        {
            _booksRepository = bookRepository;
        }

        // GET: api/<LibBooksController>
        [HttpGet]
        public async Task<IActionResult> GetBooksAsync()
        {
            var result = await _booksRepository.GetBooksAsync();
            return Ok(result);
        }

        // GET api/<LibBooksController>/5
        [HttpGet("{bookId}")]
        public async Task<IActionResult> GetBookByIdAsync([FromRoute] string bookId)
        {
            try
            {
                var result = await _booksRepository.GetBookByIdAsync(bookId);
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

        // POST api/<LibBooksController>
        [HttpPost]
        public async Task<IActionResult> AddBookAsync([FromBody] LibBook book, [FromServices] ILibBookAuditCardsRepository bookAuditCardsRepository)
        {
            try
            {
                var result1 = await _booksRepository.AddBookAsync(book);
                var result2 = await bookAuditCardsRepository.CreateBookAuditCardFromAddedBookAsync(book);
                result1.LibBookAuditCards.Clear();
                result2.Book = null;
                return Ok(result1);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<LibBooksController>/5
        [HttpPut("{bookId}")]
        public async Task<IActionResult> UpdateBookAsync([FromRoute] string bookId, [FromBody] LibBook book, [FromServices] ILibBookAuditCardsRepository bookAuditCardsRepository)
        {
            if (bookId != book.BookId) return BadRequest("Book Id does not match");

            try
            {
                var result1 = await _booksRepository.UpdateBookAsync(book);
                var result2 = await bookAuditCardsRepository.CreateBookAuditCardFromUpdatedBookAsync(book);
                result1.LibBookAuditCards.Clear();
                result2.Book = null;
                return Ok(result1);
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

        // DELETE api/<LibBooksController>/5/0
        [HttpDelete("{bookId}/{reason}")]
        public async Task<IActionResult> RemoveBookAsync([FromRoute] string bookId, [FromRoute] int reason, [FromBody] LibBook book, [FromServices] ILibBookAuditCardsRepository bookAuditCardsRepository)
        {
            if (bookId != book.BookId) return BadRequest("Book Id does not match");

            try
            {
                var result1 = await _booksRepository.RemoveBookAsync(book);
                var result2 = await bookAuditCardsRepository.CreateBookAuditCardFromRemovedBookAsync(book, reason);
                result1.LibBookAuditCards.Clear();
                result2.Book = null;
                return Ok(result1);
            }
            catch (NonExistenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UnavailableBookException ex)
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
