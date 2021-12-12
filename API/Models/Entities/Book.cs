//
// Author: Christina Zammit
//

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
        public Author Author {get; set;}
        public Genre Genre {get; set;}
        public int CurrentPage {get; set;}
        public int TotalPages {get; set;}
        public bool IsBookComplete {get ;set;}
        public string Comments {get; set;}
    }
}