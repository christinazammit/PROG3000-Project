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

    }
}