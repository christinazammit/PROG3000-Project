//
// Author: Christina Zammit
//

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

    // controller that displays the database of books 

    [ApiController]
    [Route("api/[controller]")]
    public class DisplayController : Controller
    {
        // creates instance of DataContext class
        private readonly DataContext _context;

        // initializer
        public DisplayController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        } 

        // GET method to display all books in the database
        [HttpGet("books")] // api/display/books
        public IActionResult GetAllBooks()
        {
            // creates a list of books
            List<Book> books = new List<Book>();

            // iterates over the books in the database
            foreach (var book in _context.Books.Include(x => x.Author))
            {
                // for each book, create a new book instance with id, title, author, genre, current page, total pages, is book completed, and comments
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

                // adds the instance of book to the list
                books.Add(gotBook);
            }

            // returns the books list
            return Ok(books);
        }

        // GET method that displays all completed books in the database
        [HttpGet("completed")] // api/display/completed
        public IActionResult GetAllCompletedBooks()
        {
            // creates a list of books that will store completed books
            List<Book> books = new List<Book>();

            // iterates through book database where IsBookCompleted is true
            foreach (var book in _context.Books.Include(x => x.Author).Where(x => x.IsBookComplete.Equals(true)))
            {
                // for each book, create a new book instance with id, title, author, genre, current page, total pages, is book completed, and comments
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

                // adds the instance of book to the list
                books.Add(gotBook);
            }

            // If there are no completed books, returns the following message to user
            if (!books.Any())
            {
                return Content("You have no completed books");
            }
            else 
            {
                // If there are completed books in the database, return the list of books
                return Ok(books);
            }
        }
    }
}