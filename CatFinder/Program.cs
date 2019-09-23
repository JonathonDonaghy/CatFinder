using System;
using System.Collections.Specialized;


namespace CatFinder
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.Title = "CatFinder - Extracting data from JSON body";

            //get json body as list
            string URL = "http://agl-developer-test.azurewebsites.net/people.json";
            //allowing for Custom URL entry.
            if (args.Length > 0)
            {
                URL = args[0];
            }
            //retrieve the json from URL
            string jsonBody = Services.DataService.retrieveJsonStringFromURL(URL);

            //extract the cats
            Filters.Cats FactoryCat = new Filters.Cats();
            OrderedDictionary cats = FactoryCat.getCats.ExtractCatsFromJson(jsonBody);

            //Print data
            PrintData.printToScreen(cats);

            Console.ReadLine();
        }
    }
}
