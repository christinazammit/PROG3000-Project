using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using API.Models.Persistence;

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
    }
}