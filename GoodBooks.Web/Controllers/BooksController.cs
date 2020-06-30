using System;
using GoodBooks.Data.Models;
using GoodBooks.Services;
using GoodBooks.Web.RequestModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GoodBooks.Web.Controllers
{
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBookService _bookService;

        public BooksController(ILogger<BooksController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        // IBookService: public List<Book> GetAllBooks();
        [HttpGet("/api/books")]
        public ActionResult GetBooks()
        {
            var books = _bookService.GetAllBooks();
            return Ok(books);
        }

        // IBookService: public Book GetBook(int bookId);
        [HttpGet("/api/books/{id}")]
        public ActionResult GetBook(int id)
        {
            var book = _bookService.GetBook(id);
            return Ok(book);            
        }  

        // IBookService: public void AddBook(Book book);
        [HttpPost("/api/books")]
        public ActionResult CreateBook([FromBody] NewBookRequest bookRequest)
        {
            if (!ModelState.IsValid) {
                return BadRequest("Model state note valid.");
            }
            
            var now = DateTime.UtcNow;

            var book = new Book {
                CreatedOn = now,
                UpdatedOn = now,
                Title = bookRequest.Title,
                Author = bookRequest.Author
            };

            _bookService.AddBook(book);
            return Ok($"Book created: {book.Title}");
        }

        // IBookService: public void DeleteBook(int bookId);
        [HttpDelete("/api/books/{id}")]
        public ActionResult DeleteBook(int id)
        {
            _bookService.DeleteBeook(id);
            return Ok("Book deleted with ID: {id}");
        }          
    }
}
