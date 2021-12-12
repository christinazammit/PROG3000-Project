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
    // class that creates database tables and inherits DbContext
    public class DataContext : DbContext
    {
        // creates the Books table
        public DbSet<Book> Books {get; set;}

        // creates the Authors table
        public DbSet<Author> Authors {get; set;}
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Creates the book.db database
            optionsBuilder.UseSqlite("FileName=book.db");
        }
    }
}