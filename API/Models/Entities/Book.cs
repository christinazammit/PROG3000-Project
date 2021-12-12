//
// Author: Christina Zammit
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Entities
{
    // class that stores properties of the books
    public class Book
    {
        // variable that contains books id
        public Guid Id {get; set;}

        // variable that contains books title
        public string Title {get; set;}

        // variable that contains books author
        public Author Author {get; set;}

        // variable that contains books genre
        public Genre Genre {get; set;}

        // variable that contains books current page
        public int CurrentPage {get; set;}

        // variable that contains books total pages
        public int TotalPages {get; set;}

        // variable that contains if the book is completed or still in progress
        public bool IsBookComplete {get ;set;}

        // variable that contains books comments
        public string Comments {get; set;}
    }
}