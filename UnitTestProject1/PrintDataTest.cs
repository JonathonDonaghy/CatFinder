using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using CatFinder;
using System.Threading;

namespace CatFinderTests
{
    [TestClass]
    public class PrintDataTest
    {
        [TestMethod]
        public void checkPrintedData()
        {
            //to read console output
            StringWriter output = new StringWriter();
            Console.SetOut(output);

            //create dummy cat-Dictionary values
            ArrayList maleCats = new ArrayList();
            maleCats.AddRange(new string[] { "bill", "bob", "sam" });
            ((ArrayList)Globals.cats["Male"]).AddRange(maleCats);
            
            ArrayList femaleCats = new ArrayList();
            femaleCats.AddRange(new string[] { "sarah", "Sam", "Zelda" });
            ((ArrayList)Globals.cats["Female"]).AddRange(femaleCats);
            
            PrintData.printToScreen();
            //can be a delay with print to sceen, causing a false error. delay to avoid
            Thread.Sleep(1000);

            string outputString = output.ToString();
            string[] lines = outputString.Split(
            new[] { Environment.NewLine }, StringSplitOptions.None);

            //the Console output should match below
            //first line: male header
            Assert.IsTrue(lines[0] == "Male");
            //one line gap before first male-owned cat
            Assert.IsTrue(lines[2].Contains("bill"));
            //empty lines between male and female owned cats
            Assert.IsTrue(lines[5] == "");
            //Female-owned cats should start here
            Assert.IsTrue(lines[7] == "Female");
            //first Female owned cat
            Assert.IsTrue(lines[9].Contains("sarah"));
            //should be a total of 14 lines in the return from our
            //custom cats values, + 1 from 'lines' variable declaration.
            Assert.IsTrue(lines.Length == 15);


        }
    }
}
