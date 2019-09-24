using System;
using System.Collections;
using System.Collections.Specialized;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using CatFinder;
using System.Threading;
using Newtonsoft.Json.Linq;

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
            OrderedDictionary cats = new OrderedDictionary();

            //create dummy cat-Dictionary values
            IList maleCats = new ArrayList();
            
 
            JObject bill = new JObject();
            bill.Add("name", "bill");
            JObject bob = new JObject();
            bob.Add("name", "bob");
            JObject sam = new JObject();
            sam.Add("name", "sam");

            maleCats.Add(bill);
            maleCats.Add(bob);
            maleCats.Add(sam);
           
            cats.Add("Male", maleCats);

            IList femaleCats = new ArrayList();
                        
            JObject sarah = new JObject();
            sarah.Add("name", "Sarah");
            JObject zelda = new JObject();
            zelda.Add("name", "Zelda");

            femaleCats.Add(sam);
            femaleCats.Add(sarah);
            femaleCats.Add(zelda);

            cats.Add("Female", femaleCats);

            //dummy values created

            PrintData.printToScreen(cats);

            //generate and split the console ouput
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
            //Second Female owned cat
            Assert.IsTrue(lines[10].Contains("Sarah"));
            //Total expected lines returned
            Assert.IsTrue(lines.Length == 15);


        }
    }
}
