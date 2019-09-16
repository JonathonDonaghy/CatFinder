using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CatFinder;

namespace UnitTestProject1
{   [TestClass]
    class SortOwnersTest
    {
        [TestMethod]
        public void CheckSorted()
        {
            Owner[] ownersTest = new Owner[5];
            ownersTest[0] = new Owner("jane", "Female", "22", null);
            ownersTest[1] = new Owner("bob", "Male", "22", null);
            ownersTest[2] = new Owner("bill", "Male", "22", null);
            ownersTest[3] = new Owner("Jill", "Female", "22", null);
            //4 left empty to test null values
            CatFinder.Globals.owners = ownersTest;
            SortOwners.SortByGender();

            Assert.IsTrue(Globals.owners[0].getGender == "Male");
            Assert.IsTrue(Globals.owners[1].getGender == "Male");
            Assert.IsTrue(Globals.owners[2].getGender == "Female");
            Assert.IsTrue(Globals.owners[3].getGender == "Female");

        }

    }
}
