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
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService service, ILogger<UserController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<Models.UserModel>>> Get(CancellationToken cancel)
        {
            _logger.LogWarning("Début d'une logn attente !");
            // await Task.Delay(10000, cancel);
            //Simuler une long attente
            for(int i = 0; i < 10; i++)
            {
                _logger.LogWarning($"Je passe pour le {i} is not cancellation.");
                cancel.ThrowIfCancellationRequested();
                Thread.Sleep(10000);
            }
            var result =  _service.GetUsers();
            _logger.LogWarning("Fin d'une log attente -Found  users");
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
