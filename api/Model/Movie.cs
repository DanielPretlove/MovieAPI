using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class Movie
    {
        public Guid Id {get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Rating { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }
    }
}