using System;
using System.Collections;
using System.Collections.Specialized;
using Newtonsoft.Json.Linq;
namespace CatFinder
{
    public static class PrintData
    {
        public static void printToScreen(OrderedDictionary cats)
        {
            foreach (DictionaryEntry catGroup in cats)
            {
                Console.WriteLine(catGroup.Key + Environment.NewLine);
                foreach (JObject catData in (IList)catGroup.Value)
                {
                    Console.WriteLine(" - " + catData["name"]);
                }
                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}
