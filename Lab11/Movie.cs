using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    class Movie
    {
        public string Title {  get;private  set; }
        public string Category { get;private set; }

        public Movie(string title, string category)
        {
            Title = title;
            Category = category;
        }
    }
}
