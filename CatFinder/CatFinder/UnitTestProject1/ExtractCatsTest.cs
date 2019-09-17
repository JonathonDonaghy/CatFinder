using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CatFinder;

namespace CatFinderTests
{
    [TestClass]
    public class ExtractCatsTest
    {
        [TestMethod]
        public void CheckCats()
        {
            Owner[] ownersTest = new Owner[5];
            Pets pet1 = new Pets("molly", "dog");
            Pets pet2 = new Pets("silly", "dog");
            Pets pet3 = new Pets("fishy", "Cat");
            Pets pet4 = new Pets("sally", "Cat");
            Pets pet5 = new Pets("sofa", "Cat");
            Pets pet6 = new Pets("cati", "Cat");
            Pets pet7 = new Pets("dog", "Cat");
            Pets pet8 = new Pets("billy", "dog");
            Pets pet9 = new Pets("cat", "dog");
            Pets pet10 = new Pets("horse", "Cat");


            ownersTest[0] = new Owner("jane", "Female", "22", new Pets[2] { pet1, pet3 });
            ownersTest[1] = new Owner("bob", "Male", "22", new Pets[5] { pet2, pet4, pet7, pet9, pet10 });
            ownersTest[2] = new Owner("bill", "Male", "22", null);
            ownersTest[3] = new Owner("Jill", "Female", "22", new Pets[3] { pet5, pet6, pet8 });

            //4 left empty to test null values
            Globals.owners = ownersTest;
            Assert.IsTrue(ownersTest.Length == 5);

            ExtractCats.ExtractCatsFromOwners();

            Assert.IsTrue(Globals.cats.Count == 2);
            Assert.IsTrue(Globals.cats.ContainsKey("Male"));
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
