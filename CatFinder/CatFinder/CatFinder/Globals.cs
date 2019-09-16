using System;
using System.Collections;
namespace CatFinder
{
    public static class Globals
    {
        public static Owner[] owners;

        static Globals()
        {
            //dummy value to avoid nullexceptions if it gets called early
            //should be set to a compleated array on first use.
            owners = new Owner[0];
        }

    }
}
