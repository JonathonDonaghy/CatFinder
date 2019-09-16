using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CatFinder;

namespace CatFinderTests
{
    [TestClass]
    class ExtractCatsTest
    {
        [TestMethod]
        public void CheckSorted()
        {
            Owner[] ownersTest = new Owner[5];
            Pets pet1 = new Pets("molly", "dog");
            Pets pet2 = new Pets("silly", "dog");
            Pets pet3 = new Pets("fishy", "cat");
            Pets pet4 = new Pets("sally", "cat");
            Pets pet5 = new Pets("sofa", "cat");
            Pets pet6 = new Pets("cati", "cat");
            Pets pet7 = new Pets("dog", "cat");
            Pets pet8 = new Pets("billy", "dog");
            Pets pet9 = new Pets("cat", "dog");
            Pets pet10 = new Pets("horse", "cat");

            
            ownersTest[0] = new Owner("jane", "Female", "22", new Pets[2] {pet1, pet3 });
            ownersTest[1] = new Owner("bob", "Male", "22", new Pets[5] {pet2, pet4, pet7, pet9, pet10 });
            ownersTest[2] = new Owner("bill", "Male", "22", null);
            ownersTest[3] = new Owner("Jill", "Female", "22", new Pets[3] {pet5, pet6, pet8 });
            //4 left empty to test null values
            CatFinder.Globals.owners = ownersTest;
            ExtractCats.ExtractCatsFromOwners();

            Assert.IsTrue(Globals.cats.Count == 2);
            Assert.IsTrue(((Pets)((ArrayList)Globals.cats["Male"])[0]).getName == "dog");
            Assert.IsTrue(((Pets)((ArrayList)Globals.cats["Male"])[2]).getName == "sally");
            Assert.IsTrue(((Pets)((ArrayList)Globals.cats["Female"])[0]).getName == "cati");
            Assert.IsTrue(((Pets)((ArrayList)Globals.cats["Female"])[2]).getName == "sofa");

        }

    }
}
