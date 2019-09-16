using System;
using System.Collections;

namespace CatFinder
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //get json body as list
            string URL = "http://agl-developer-test.azurewebsites.net/people.json";
            //allowing for Custom URL entry.
            if (args.Length > 0)
            {
                URL = args[0];
            }
            Globals.owners = GetJSON.retrieveJSON(URL);
            //extract the cats
            ExtractCats.ExtractCatsFromOwners();
            
            //Print data

            Console.ReadKey();
            throw new NotImplementedException("nyi");
        }
    }
}
