using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Repositories;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UsersController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _repository.GetAll();
            return Ok(users);
        }
    }
}
