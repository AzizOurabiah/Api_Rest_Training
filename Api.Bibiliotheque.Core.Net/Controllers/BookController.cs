using Api.Bibiliotheque.Core.Net.Interfaces;
using Api.Bibiliotheque.Core.Net.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Bibiliotheque.Core.Net.Controllers
{
    
    //[controller] = Book
    //[action] = action de la méthode
    //mot clé réservé : area, handler, page, ...(d'autres avec blazor)
    [Route("api/maroute/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;
        private readonly ILogger<BookController> _logger;

        public BookController(IBookService service, ILogger<BookController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Permet d'obtenir la liste des livres de la bibliothèques
        /// </summary>
        /// <remarks>
        /// Example de requête :
        /// POST /monget/mongetge {avec in id = "id, et une valeur = "valeur", ...}
        /// </remarks>
        /// <response code="400">Erreur pour trouver la requete</response>
        /// <response code="200">Une liste de books</response>
        /// <response code="401">Authentification necessaire</response>
        /// <returns>Return a list of books</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet("monget/mongetget")]        
        public async Task<ActionResult<List<Models.BookModel>>> Get()
        {
            _logger.LogInformation("Début de logger !");
            var result = await _service.GetBooks();
            _logger.LogError("Log error -fin de logger- !");
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.BookModel>> Get(int id)
        {
            var result = await _service.GetBook(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Models.BookModel>> Post(BookModel book)
        {
            var result = await _service.AddBook(book);
            return CreatedAtAction("Post", result);
        }

        [HttpPut]
        public async Task<ActionResult<Models.BookModel>> Put(int id, BookModel book)
        {
            var result = await _service.UpdateBook(id,book);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<Models.BookModel>> Delete(int id)
        {
            var result = await _service.DeleteBook(id);
            return Ok(result);
        }
    }
}
