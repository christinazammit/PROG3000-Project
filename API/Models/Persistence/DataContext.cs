//
// Author: Christina Zammit
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using API.Models.Entities;

namespace API.Models.Persistence
{
    public class DataContext : DbContext
    {
        public DbSet<Book> Books {get; set;}
        public DbSet<Author> Authors {get; set;}
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("FileName=book.db");
        }
    }
}