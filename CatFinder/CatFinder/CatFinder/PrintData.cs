using System;
using System.Collections;
namespace CatFinder
{
    public static class PrintData
    {
        public static void printToScreen()
        {
            foreach (DictionaryEntry catGroup in Globals.cats)
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
