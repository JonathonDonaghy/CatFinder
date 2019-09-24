using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CatFinder;
using System.Collections.Specialized;
using System.Linq;
using System.IO;
using System;
using Newtonsoft.Json.Linq;


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
            string mockJson = File.ReadAllText(Environment.CurrentDirectory + "\\Resources\\MockJSON.txt");

            
            CatFinder.Filters.Cats catFactory = new CatFinder.Filters.Cats();
            ExtractCats cats = catFactory.getCats;
            //4 left empty to test null values
            
            OrderedDictionary catTable = cats.ExtractCatsFromJson(mockJson);

            // should be two entries
            Assert.IsTrue(catTable.Count == 2);

            //check that the keys are correct
            Assert.IsTrue(catTable.Cast<DictionaryEntry>().ElementAt(0).Key.ToString() == "Male");
            Assert.IsTrue(catTable.Cast<DictionaryEntry>().ElementAt(1).Key.ToString() == "Female");
            Console.WriteLine(catTable[0]);
            //should be 4 male owned cats and 3 female owned cats
            Assert.IsTrue(((IList)catTable[0]).Count == 4);
            Assert.IsTrue(((IList)catTable[1]).Count == 3);

            //create array of cat names in expected order
            string[] mNameList = new string[] {"Garfield", "Jim", "Max", "Tom" };
            string[] fNameList = new string[] { "Garfield", "Simba", "Tabby" };
            //check all male-owned cats are present in the correct order
            for (int i = 0; i < ((IList)catTable[0]).Count; i++)
            {
                JObject cat = (JObject)((IList)catTable[0])[i];
                Assert.IsTrue(cat["name"].ToString() == mNameList[i]);
            }
            //check all female-owned cats are in the correct order
            for (int i = 0; i < ((IList)catTable[1]).Count; i++)
            {
                JObject cat = (JObject)((IList)catTable[1])[i];
                Assert.IsTrue(cat["name"].ToString() == fNameList[i]);
            }

            //as we have confirmed that the length of all lists is correct,
            //and each of the values, the result has the right data 
            //if the test passes
            
        }

    }


}


