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
    public class UpdateController : ControllerBase
    {
        private readonly DataContext _context;

        public UpdateController(DataContext context)
        {
            _context = context;
        }

        [HttpPut("{id}")] // api/update/id
        public async Task<IActionResult> UpdateBook(string id, Book book)
        {
            try
            {
                var bookInDb = await _context.Books.Include(x => x.Author).FirstOrDefaultAsync(x => x.Id.Equals(new Guid(id)));

                if (bookInDb == null) 
                {
                    return NotFound();
                }

                bookInDb.Title = book.Title;
                bookInDb.Author = new Author {
                    FirstName = book.Author.FirstName,
                    LastName = book.Author.LastName,
                };
                bookInDb.Genre = book.Genre;
                bookInDb.Comments = book.Comments;

                await _context.SaveChangesAsync();
                return Ok(bookInDb);

            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}/currentpage")] // api/update/id/currentpage
        public async Task<IActionResult> UpdateCurrentPage(string id, Book book)
        {
            try
            {
                var bookInDb = await _context.Books.FindAsync(new Guid(id));

                if (bookInDb == null) 
                {
                    return NotFound();
                }

                bookInDb.CurrentPage = book.CurrentPage;
                bookInDb.IsBookComplete = book.IsBookComplete;

                await _context.SaveChangesAsync();
                return Ok(bookInDb);

            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}