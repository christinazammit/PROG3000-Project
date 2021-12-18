//
// Author: Chanpreet Kaur
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
    public class FindController : Controller
    {
        // creates instance of DataContext class
        private readonly DataContext _context;

        // initializer
        public FindController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        } 

        // GET: api/find/
        [HttpGet("{name}")]
        public async Task<ActionResult<Book>> GetBookByName(string name)
        {
            var book = await _context.Books.Where(x => x.Title.Contains(name)).FirstOrDefaultAsync();

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

    }
}