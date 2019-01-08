using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PongStudiosPortal.Models
{
    public class Person
    {             
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }        
        public int GenderId { get; set; }
    }
}
