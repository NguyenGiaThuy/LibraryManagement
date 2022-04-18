using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibLibrariansController : ControllerBase
    {
        private readonly ILibLibrarianRepository _repository;

        public LibLibrariansController(ILibLibrarianRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<LibLibrariansController>/Memberships
        [HttpGet("Memberships")]
        public async Task<IActionResult> GetAllMembershipsAsync()
        {
            var result = await _repository.GetMembershipsAsync();
            return Ok(result);
        }

        // GET api/<LibLibrariansController>/Memberships/5
        [HttpGet("Memberships/{membershipId}")]
        public async Task<IActionResult> GetMembershipByIdAsync([FromRoute] string membershipId)
        {
            try
            {
                var result = await _repository.GetMembershipByIdAsync(membershipId);
                return Ok(result);
            } 
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/<LibMembershipsController>/Memberships
        [HttpPost("Memberships")]
        public async Task<IActionResult> CreateMembershipAsync([FromBody] LibMembership Membership)
        {
            try 
            {
                var result = await _repository.CreateMembershipAsync(Membership);
                return Ok(Membership);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<LibMembershipsController>/Memberships/5
        [HttpPut("Memberships/{membershipId}")]
        public async Task<IActionResult> UpdateMembershipAsync([FromRoute] string membershipId, [FromBody] LibMembership Membership)
        {
            try
            {
                var result = await _repository.UpdateMembershipAsync(membershipId, Membership);
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

        // DELETE api/<LibMembershipsController>/Memberships/5
        [HttpDelete("Memberships/{membershipId}")]
        public async Task<IActionResult> DeleteMembershipAsync([FromRoute] string membershipId)
        {
            try
            {
                var result = await _repository.DeleteMembershipAsync(membershipId);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/<LibLibrariansController>/Books
        [HttpGet("Books")]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            var result = await _repository.GetBooksAsync();
            return Ok(result);
        }

        // GET api/<LibLibrariansController>/Books/5
        [HttpGet("Books/{isbn}")]
        public async Task<IActionResult> GetBookByIdAsync([FromRoute] string isbn)
        {
            try
            {
                var result = await _repository.GetBookByISBNAsync(isbn);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        

        // PUT api/<LibBooksController>/Books/5
        [HttpPut("Books/{isbn}")]
        public async Task<IActionResult> UpdateBookAsync([FromRoute] string isbn, [FromBody] LibBook Book)
        {
            try
            {
                var result = await _repository.UpdateBookAsync(isbn, Book);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<LibMembershipsController>/Callcards
        [HttpPost("Callcards")]
        public async Task<IActionResult> CreateCallCardAsync([FromBody] LibCallCard callcard)
        {
            try
            {
                var result = await _repository.CreateCallCardAsync(callcard);
                return Ok(callcard);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<LibBooksController>/Callcards/5
        [HttpPut("Callcards/{id}")]
        public async Task<IActionResult> UpdateCallCardAsync([FromRoute] int id, [FromBody] LibCallCard callcard)
        {
            try
            {
                var result = await _repository.UpdateCallCardAsync(id, callcard);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/<LibUsersController>/Callcards
        [HttpGet("Callcards")]
        public async Task<IActionResult> GetAllCallCardAsync()
        {

            var result = await _repository.GetCallCardAsync();
            return Ok(result);
        }

        // GET api/<LibUsersController>/Callcards/5
        [HttpGet("Callcards/{Id}")]
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
