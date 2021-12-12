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
    // controller that allows user to update a book in database
    [ApiController]
    [Route("api/[controller]")]
    public class UpdateController : ControllerBase
    {
        // creates an instance of DataContext
        private readonly DataContext _context;

        // initializer
        public UpdateController(DataContext context)
        {
            _context = context;
        }

        // PUT method that allows user to update book given the id
        [HttpPut("{id}")] // api/update/id
        public async Task<IActionResult> UpdateBook(string id, Book book)
        {
            try
            {   
                // retrieves book from the database that matches corresponding id
                var bookInDb = await _context.Books.Include(x => x.Author).FirstOrDefaultAsync(x => x.Id.Equals(new Guid(id)));

                // if the book is not found, return 404 error
                if (bookInDb == null) 
                {
                    return NotFound();
                }

                // sets the book title to the title input by the user
                bookInDb.Title = book.Title;

                // sets the book author to the author input by the user
                bookInDb.Author = new Author {
                    FirstName = book.Author.FirstName,
                    LastName = book.Author.LastName,
                };

                // sets the book genre to the genre input by the user
                bookInDb.Genre = book.Genre;

                // sets the book comment to the comment input by the user
                bookInDb.Comments = book.Comments;

                // saves changes to the database
                await _context.SaveChangesAsync();

                // returns the updated book
                return Ok(bookInDb);

            }

            // if error occurs, return BadRequest
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        // PUT method that allows user to update the users progress 
        [HttpPut("{id}/currentpage")] // api/update/id/currentpage
        public async Task<IActionResult> UpdateCurrentPage(string id, Book book)
        {
            try
            {
                // retrieves book from the database that matches corresponding id
                var bookInDb = await _context.Books.FindAsync(new Guid(id));

                // if the book is not found, return 404 error
                if (bookInDb == null) 
                {
                    return NotFound();
                }

                // sets the books current page to the current page input by the user
                bookInDb.CurrentPage = book.CurrentPage;

                // updates the book completion as input by the user
                bookInDb.IsBookComplete = book.IsBookComplete;

                // sets the book comment to the comment input by the user
                bookInDb.Comments = book.Comments;

                // saves changes to the database
                await _context.SaveChangesAsync();

                 // returns the updated book
                return Ok(bookInDb);

            }
            // if error occurs, return BadRequest
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}