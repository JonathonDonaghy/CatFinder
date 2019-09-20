using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Threading.Tasks;

namespace CatFinder.Filters
{

    public class Cats
    {
        //Hashtable cats = new Hashtable();
         ExtractCats extractCats;
        public Cats()
        {
            extractCats = new ExtractCats();
        }
        public ExtractCats getCats
        {
            get { return extractCats; }
        }
        
    }
}
