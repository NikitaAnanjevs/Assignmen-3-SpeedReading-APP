using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeedReading_5x5.Models
{
    public class Results
    {
        public int Id { get; set; }
      
        public int WordNumber { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int BooksId { get; set; }
        public Books Books { get; set; }   

    }
}