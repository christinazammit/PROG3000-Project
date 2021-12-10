using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using API.Models.Persistence;
using API.Models.Entities;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DisplayController : Controller
    {
        private readonly DataContext _context;

        public DisplayController(DataContext context)
        {
            _context = context;
        }

        [Route("/NotFound")]
        public IActionResult PageNotFound()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        } 

        [HttpGet("books")] // api/display/books
        public IActionResult GetAllBooks()
        {
            List<Book> books = new List<Book>();

            foreach (var book in _context.Books.Include(x => x.Author))
            {
                var gotBook = new Book {
                    Id = book.Id,
                    Title = book.Title,
                    Author = new Author {
                        FirstName = book.Author.FirstName,
                        LastName = book.Author.LastName,
                    },
                    Genre = book.Genre,
                    CurrentPage = book.CurrentPage,
                    TotalPages = book.TotalPages,
                    IsBookComplete = book.IsBookComplete,
                    Comments = book.Comments,
                };

                books.Add(gotBook);
            }

            return Ok(books);
        }
    }
}