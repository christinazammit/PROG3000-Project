//
// Author: Chanpreet Kaur
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Entities
{
    public class Author
    {
        public Guid Id {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
    }
}