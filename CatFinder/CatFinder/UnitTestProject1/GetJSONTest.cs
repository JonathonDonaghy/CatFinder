using Microsoft.VisualStudio.TestTools.UnitTesting;
using CatFinder;

namespace CatFinderTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckJSON()
        {
            //GetJSON.retrieveJSON("URL");
            Assert.IsNotNull(GetJSON.retrieveJSON("http://agl-developer-test.azurewebsites.net/people.json"));
            Assert.IsTrue(GetJSON.retrieveJSON("http://agl-developer-test.azurewebsites.net/people.json").Length == 6);
            //Assert.IsTrue(false);
        }
    }
}
