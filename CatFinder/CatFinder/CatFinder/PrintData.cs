﻿using System;
using System.Collections;
namespace CatFinder
{
    public class PrintData
    {
        public static void PrintToScreen()
        {
            foreach (DictionaryEntry CatGroup in Globals.cats)
            {
                Console.WriteLine(CatGroup.Key + Environment.NewLine);
                foreach (string catname in (ArrayList)CatGroup.Value)
                {
                    Console.WriteLine(" - " + catname);
                }
                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}
