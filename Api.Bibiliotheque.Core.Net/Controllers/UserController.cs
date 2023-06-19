using Api.Bibiliotheque.Core.Net.Interfaces;
using Api.Bibiliotheque.Core.Net.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Bibiliotheque.Core.Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Models.UserModel>>> Get()
        {
            var result = await _service.GetUsers();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.UserModel>> Get(int id)
        {
            var result = await _service.GetUser(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Models.UserModel>> Post(UserModel user)
        {
            var result = await _service.AddUser(user);
            return CreatedAtAction("Post", result);
        }

        [HttpPut]
        public async Task<ActionResult<Models.UserModel>> Put(int id, UserModel user)
        {
            var result = await _service.UpdateUser(id, user);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<Models.UserModel>> Delete(int id)
        {
            var result = await _service.DeleteUser(id);
            return Ok(result);
        }


    }
}
