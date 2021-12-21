using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AuthorAPI.Data.Impl;
using AuthorAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthorAPI.Controllers
{
    [ApiController]
    [Route("/books")]
    public class BookController : ControllerBase
    {
        private IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            this._bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Book>>> GetBooksAsync()
        {
            try
            {
                IList<Book> books = await _bookRepository.GetAllBooksAsync();
                return Ok(books);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("{authorId:int}")]
        public async Task<ActionResult<Book>> AddBookAsync([FromRoute] int authorId, [FromBody] Book book)
        {
            try
            {
                Book added = await _bookRepository.AddBookAsync(authorId, book);
                return Created($"/{added.Isbn}", added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{isbn:int}")]
        public async Task<ActionResult<Book>> DeleteBookAsync([FromRoute] int isbn)
        {
            try
            {
                Book removed = await _bookRepository.DeleteBookAsync(isbn);
                return Ok(removed);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("{isbn:int}")]
        public async Task<ActionResult<Book>> GetBookByIsbnAsync([FromRoute] int isbn)
        {
            try
            {
                Book book = await _bookRepository.GetBookByIsbnAsync(isbn);
                return Ok(book);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        [Route("{isbn:int}")]
        public async Task<ActionResult<Book>> UpdateBookAsync([FromBody] Book book)
        {
            try
            {
                Book updatedBook = await _bookRepository.UpdateBookAsync(book);
                return Ok(updatedBook);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}