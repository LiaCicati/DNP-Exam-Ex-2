using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AuthorAPI.Data;
using AuthorAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthorAPI.Controllers
{
    [ApiController]
    [Route("/authors")]
    public class AuthorController : ControllerBase
    {
        private IAuthorRepository _repository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            this._repository = authorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Author>>> GetAuthorsAsync()
        {
            try
            {
                IList<Author> authors = await _repository.GetAllAuthorsAsync();
                return Ok(authors);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<Author>> AddAdultAsync([FromBody] Author author)
        {
            try
            {
                Author added = await _repository.AddAuthorAsync(author);
                return Created($"/{added.Id}", added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}