using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using CatFinder;
namespace CatFinderTests
{
    [TestClass]
    public class PrintDataTest
    {
        [TestMethod]
        public void checkPrintedData()
        {
            StringWriter output = new StringWriter();
            Console.SetOut(output);
            ArrayList maleCats = new ArrayList();
            maleCats.AddRange(new string[] {"bill", "bob", "sam" });
            Globals.cats.Add("Male", maleCats);

            ArrayList femaleCats = new ArrayList();
            femaleCats.AddRange(new string[] { "sarah", "Sam", "Zelda" });
            Globals.cats.Add("Female", femaleCats);

            PrintData.PrintToScreen();

            string outputString = output.ToString();
            string[] lines = outputString.Split(
            new[] { Environment.NewLine }, StringSplitOptions.None);

            Assert.IsTrue(lines[0] == "Male");
            Assert.IsTrue(lines[1] == "bill");
            Assert.IsTrue(lines[4] == "");
            Assert.IsTrue(lines[5] == "Female");
            Assert.IsTrue(lines[6] == "sarah");
            Assert.IsTrue(lines.Length == 11);


        }
    }
}
