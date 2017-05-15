using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeedReading_5x5.Models
{
    public class Books
    {
        public Books ()
        {
            Results = new List<Results>();

        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Bodytext { get; set; }
        public List<Results> Results{ get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }


    }
}