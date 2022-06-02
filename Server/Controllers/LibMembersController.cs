using Microsoft.AspNetCore.Mvc;
using Server.Helpers.Exceptions;
using Server.Models;
using Server.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibMembersController : ControllerBase
    {
        private readonly ILibMembersRepository _membersRepository;

        public LibMembersController(ILibMembersRepository membersRepository)
        {
            _membersRepository = membersRepository;
        }

        // GET: api/<LibMembersController>
        [HttpGet]
        public async Task<IActionResult> GetMembersAsync()
        {
            var result = await _membersRepository.GetMembersAsync();
            return Ok(result);
        }

        // GET api/<LibMembersController>/5
        [HttpGet("{memberId}")]
        public async Task<IActionResult> GetMemberByIdAsync([FromRoute] string memberId)
        {
            try
            {
                var result = await _membersRepository.GetMemberByIdAsync(memberId);
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

        // GET api/<LibMembersController>/membership/5
        [HttpGet("membership/{membershipId}")]
        public async Task<IActionResult> GetMemberByMembershipIdAsync([FromRoute] string membershipId)
        {
            try
            {
                var result = await _membersRepository.GetMemberByMembershipIdAsync(membershipId);
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

        // GET api/<LibMembersController>/social/5
        [HttpGet("social/{socialId}")]
        public async Task<IActionResult> GetMemberBySocialIdAsync([FromRoute] string socialId)
        {
            try
            {
                var result = await _membersRepository.GetMemberBySocialIdAsync(socialId);
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

        // POST api/<LibMembersController>
        [HttpPost]
        public async Task<IActionResult> CreateMemberAsync([FromBody] LibMember member, [FromServices] ILibMembershipsRepository membershipsRepository)
        {
            try
            {
                var result1 = await _membersRepository.CreateMemberAsync(member);
                var result2 = await membershipsRepository.CreateMembershipFromMemberAsync(member);
                var result3 = await _membersRepository.UpdateMemberhipIdforMemberAsync(result1, result2);
                return Ok(string.Format("{0}\n{1}", result3, result2));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<LibMembersController>/5
        [HttpPut("{memberId}")]
        public async Task<IActionResult> UpdateMemberAsync([FromRoute] string memberId, [FromBody] LibMember member)
        {
            if (memberId != member.MemberId) return BadRequest("Member Id does not match");

            try
            {
                var result = await _membersRepository.UpdateMemberAsync(member);
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
