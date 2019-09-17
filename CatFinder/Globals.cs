using System;
using System.Collections;
namespace CatFinder
{
    public static class Globals
    {
        public static Owner[] owners;
        public static Hashtable cats;
        
        static Globals()
        {
            //dummy value to avoid nullexceptions if it gets called early
            //should be set to a empty value on first call of globals class.
            owners = new Owner[0];
            cats = new Hashtable();

            //adding values to cats dictionary to ensure Male-female order. 
            cats.Add("Male", new ArrayList());
            cats.Add("Female", new ArrayList());

        }

    }
}
