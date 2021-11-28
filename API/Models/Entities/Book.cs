using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Entities
{
    public class Book
    {
        public Guid Id {get; set;}
        public string Title {get; set;}
        public List<Author> Author {get; set;}
        public Genre Genre {get; set;}
        public int PageNumber {get; set;}
    }
}