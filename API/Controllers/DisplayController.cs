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

        // add a book, CHANPREETS PART
        [HttpPost("add")] // api/display/add
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            var newBook = new Book {
                Id = Guid.NewGuid(),
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

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return Ok(newBook);
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

        [HttpGet("completed")] // api/display/completed
        public IActionResult GetAllCompletedBooks()
        {
            List<Book> books = new List<Book>();

            foreach (var book in _context.Books.Include(x => x.Author).Where(x => x.IsBookComplete.Equals(true)))
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

            if (!books.Any())
            {
                return Content("You have no completed books");
            }
            else 
            {
                return Ok(books);
            }
        }
    }
}