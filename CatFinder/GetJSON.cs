using System;
using System.Collections;
using System.Net;
using Newtonsoft.Json;
namespace CatFinder
{
    public static class GetJSON
    {
        //extracts JSON string from URL
        public static Owner[] retrieveJSON(string URL)
        {
            //To avoid .NET Credentials Issues
            WebClient service = new WebClient();
            service.Proxy = WebRequest.DefaultWebProxy;
            service.Credentials = System.Net.CredentialCache.DefaultCredentials;
            service.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;

            string json;
            try
            {
                json = service.DownloadString(URL);
            }
            catch (HttpListenerException E)
            {
                Console.WriteLine("Catfinder was unable to retrieve the JSON from " + URL);
                Console.WriteLine("Error Code " + E.ErrorCode);
                Owner[] empty = new Owner[0];
                return empty;
            }
            catch
            {
                Console.WriteLine("An unknown error occoured when retrieveing the JSON body from " + URL);
                Owner[] empty = new Owner[0];
                return empty;
            }
            return JSONToArray(json);
        }

        //deserialises JSON to array of Owner objects.
        static Owner[] JSONToArray(string json)
        {

            Owner[] owners;
            try
            {
                owners = JsonConvert.DeserializeObject<Owner[]>(json);
            }
            catch(JsonException E)
            {
                Console.WriteLine("could not deserialse JSON body");
                Console.WriteLine("Body may not be in the Correct Format.");
                Console.WriteLine(E.HelpLink);
                Owner[] empty = new Owner[0];
                return empty;
            }
            catch
            {
                Console.WriteLine("An unknown error occoured when Deserializeing the JSON body");
                Owner[] empty = new Owner[0];
                return empty;
            }
            return owners;
        }


    }
}
