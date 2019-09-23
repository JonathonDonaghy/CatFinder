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
            string json = CatFinder.Services.DataService.retrieveJsonStringFromURL("http://agl-developer-test.azurewebsites.net/people.json");
            //GetJSON.retrieveJSON("URL");
            //check that a value was recieved
            Assert.IsNotNull(json);

            //check that the result isn't empty
            Assert.IsFalse(json.Trim() == "");
            
            
            
        }
    }
}
