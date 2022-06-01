using Microsoft.AspNetCore.Mvc;
using Server.Helpers.Exceptions;
using Server.Models;
using Server.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibMembershipsController : ControllerBase
    {
        private readonly ILibMembershipsRepository _membershipsRepository;

        public LibMembershipsController(ILibMembershipsRepository membershipsRepository)
        {
            _membershipsRepository = membershipsRepository;
        }

        // GET: api/<LibMembershipsController>
        [HttpGet]
        public async Task<IActionResult> GetAllMembershipsAsync()
        {
            var result = await _membershipsRepository.GetMembershipsAsync();
            return Ok(result);
        }

        // GET api/<MembershipsController>/5
        [HttpGet("{LibMembershipsController}")]
        public async Task<IActionResult> GetMembershipByIdAsync([FromRoute] string membershipId)
        {
            try
            {
                var result = await _membershipsRepository.GetMembershipByIdAsync(membershipId);
                return Ok(result);
            }
            catch (NonExistenceException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET api/<LibMembershipsController>/social/5
        [HttpGet("social/{socialId}")]
        public async Task<IActionResult> GetMembershipBySocialIdAsync([FromRoute] string socialId)
        {
            try
            {
                var result = await _membershipsRepository.GetMembershipBySocialIdAsync(socialId);
                return Ok(result);
            }
            catch (NonExistenceException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT api/<LibMembershipsController>/disable/5
        [HttpPut("disable/{membershipId}")]
        public async Task<IActionResult> DisableMembershipAsync([FromRoute] string membershipId, [FromBody] LibMembership membership)
        {
            if (membershipId != membership.MembershipId) return BadRequest("Membership Id does not match");

            try
            {
                var result = await _membershipsRepository.DisableMembershipAsync(membership);
                return Ok(result);
            }
            catch (NonExistenceException ex)
            {
                return NotFound(ex.Message);

            }
        }

        // PUT api/<LibMembershipsController>/enable/5
        [HttpPut("enable/{membershipId}")]
        public async Task<IActionResult> EnableMembershipAsync([FromRoute] string membershipId, [FromBody] LibMembership membership)
        {
            if (membershipId != membership.MembershipId) return BadRequest("Membership Id does not match");

            try
            {
                var result = await _membershipsRepository.EnableMembershipAsync(membership);
                return Ok(result);
            }
            catch (NonExistenceException ex)
            {
                return NotFound(ex.Message);

            }
        }

        // PUT api/<LibMembershipsController>/extend/5
        [HttpPut("extend/{membershipId}")]
        public async Task<IActionResult> ExtendMembershipAsync([FromRoute] string membershipId, [FromBody] LibMembership membership)
        {
            if (membershipId != membership.MembershipId) return BadRequest("Membership Id does not match");

            try
            {
                var result = await _membershipsRepository.ExtendMembershipAsync(membership);
                return Ok(result);
            }
            catch (NonExistenceException ex)
            {
                return NotFound(ex.Message);

            }
        }
    }
}