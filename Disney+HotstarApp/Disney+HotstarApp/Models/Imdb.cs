using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Disney_HotstarApp.Models
{
    public class Imdb
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string YearOfRelease { get; set; }
        public string Rating { get; set; }

        public string ImagUrl { get; set; }
        public string Review { get; set; }
    }
}