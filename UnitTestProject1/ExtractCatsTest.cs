using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CatFinder;
using System.Collections.Specialized;
using System.Linq;
using System.IO;
using System;

namespace CatFinderTests
{
    [TestClass]
    public class ExtractCatsTest
    {
        [TestMethod]
        public void CheckCats()
        {
            //mock json for generation of cats data structure
            //adding sarah
            string mockJson = File.ReadAllText(Environment.CurrentDirectory + "\\MockJSON");

            Console.WriteLine("testing rebuild");
            CatFinder.Filters.Cats catFactory = new CatFinder.Filters.Cats();
            ExtractCats cats = catFactory.getCats;
            //4 left empty to test null values
            
            OrderedDictionary catTable = cats.ExtractCatsFromJson(mockJson);
            
            // should be two entries
            Assert.IsTrue(catTable.Count == 2);

            //first entry should be Male
            Assert.IsTrue(catTable.Cast<DictionaryEntry>().ElementAt(0).Key.ToString() == "Male");

            Assert.IsTrue((string)((ArrayList)catTable["Male"])[0] == "");
            Assert.IsTrue((string)((ArrayList)catTable["Male"])[2] == "");
            Assert.IsTrue((string)((ArrayList)catTable["Female"])[0] == "");

        }

    }
}
