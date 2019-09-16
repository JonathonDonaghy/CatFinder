using System;
using System.Collections;
using System.Net;
using Newtonsoft.Json;
            namespace CatFinder
{
    public static class GetJSON
    {
        //extracts JSON string from URL
         public static Owner[]  retrieveJSON(string URL)
        {
            WebClient service = new WebClient();
            service.Proxy = WebRequest.DefaultWebProxy;
            service.Credentials = System.Net.CredentialCache.DefaultCredentials; ;
            service.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
            string json = service.DownloadString(URL);
            return JSONToArray(json);
        }

        //deserialises JSON to array of Owner objects.
        static Owner[] JSONToArray(string json){
            Owner[] owners = JsonConvert.DeserializeObject<Owner[]>(json);
            return owners;
        }


    }
}
