using System;

namespace CatFinder
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //get json body as list
            Globals.owners = GetJSON.retrieveJSON("http://agl-developer-test.azurewebsites.net/people.json");
            //sort list

            //Print data

            Console.ReadKey();
            throw new NotImplementedException("nyi");
        }
    }
}
