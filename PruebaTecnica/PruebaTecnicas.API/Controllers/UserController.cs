using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Core.Bussiness.User;
using PruebaTecnica.Core.Entities;
using PruebaTecnica.Infrastructure.Repositories.Interfaces;

namespace PruebaTecnicas.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IBaseRepository _baseRepository;

        public UserController(IUserRepository userRepository, IBaseRepository baseRepository)
        {
            _userRepository = userRepository;
            _baseRepository = baseRepository;
        }
        [HttpGet("users")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepository.FindAll();
            return Ok(users);
        }

        [HttpGet("users/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userRepository.FindById(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost("user")]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
        {
            var user = new User();
            user.Name = request.Name;
            user.Email = request.Email;
            user.Website = request.Website;
            user.Username = request.Username;
            user.Phone = request.Phone;

            await _userRepository.AddUser(user);
            await _baseRepository.SaveChangesAsyn();
            return Ok(user);
        }

        [HttpPut("user/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateUserRequest request, int id)
        {
            var user = await _userRepository.FindById(id);
            if (user == null) return NotFound();

            user.Name = request.Name;
            user.Email = request.Email;
            user.Website = request.Website;
            user.Username = request.Username;
            user.Phone = request.Phone;

            await _baseRepository.SaveChangesAsyn();
            return Ok("Usuario actualizado");
        }

        [HttpDelete("user/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userRepository.FindById(id);
            if (user == null) return NotFound();
            user.Deleted = true;
            await _baseRepository.SaveChangesAsyn();
            return Ok("Usuerio eliminado");
        }

    }
}
