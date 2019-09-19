using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CatFinder;
using System.Collections.Specialized;

namespace CatFinderTests
{
    [TestClass]
    public class ExtractCatsTest
    {
        [TestMethod]
        public void CheckCats()
        {
            string mockJson = "";
            CatFinder.Filters.Cats catFactory = new CatFinder.Filters.Cats();
            ExtractCats cats = catFactory.getCats;
            //4 left empty to test null values
            
            Hashtable catTable = cats.ExtractCatsFromJson(mockJson);

            Assert.IsTrue(catTable.Count == 2);
            Assert.IsTrue(catTable.Keys[0]);
            //Assert.IsTrue(Globals.cats.Count == 5);

            Assert.IsTrue(((ArrayList)Globals.cats["Male"]).Count > 0);
            string name = (string)((ArrayList)Globals.cats["Male"])[0];
            Assert.IsTrue(name == "dog");
            Assert.IsTrue((string)((ArrayList)Globals.cats["Male"])[2] == "sally");
            Assert.IsTrue((string)((ArrayList)Globals.cats["Female"])[0] == "cati");
            Assert.IsTrue((string)((ArrayList)Globals.cats["Female"])[2] == "sofa");

        }

    }
}
