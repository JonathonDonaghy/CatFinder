using System;
using System.Collections;
using System.Net;
using Newtonsoft.Json;
            namespace CatFinder
{
    public static class GetJSON
    {
         public static Owner[]  retrieveJSON(string URL)
        {
            string json = new WebClient().DownloadString(URL);
            Console.WriteLine(json);
            return JSONToArray(json);
        }

        static Owner[] JSONToArray(string json){
            Owner[] owners = JsonConvert.DeserializeObject<Owner[]>(json);
            return owners;
        }


    }
}
