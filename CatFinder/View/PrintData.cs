using System;
using System.Collections;
namespace CatFinder
{
    public static class PrintData
    {
        public static void printToScreen(Hashtable cats)
        {
            foreach (DictionaryEntry catGroup in cats)
            {
                Console.WriteLine(catGroup.Key + Environment.NewLine);
                foreach (string catName in (ArrayList)catGroup.Value)
                {
                    Console.WriteLine(" - " + catName);
                }
                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}
