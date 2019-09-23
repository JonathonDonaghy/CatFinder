using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;


namespace CatFinder.Services
{
    public static class DataService
    {
        public static string retrieveJsonStringFromURL(string URL)
        {
            using( WebClient WC = new WebClient() ){

                //To avoid .NET Credentials Issues
                WC.Proxy = WebRequest.DefaultWebProxy;
                WC.Credentials = System.Net.CredentialCache.DefaultCredentials;
                WC.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;

                string json = "";
                try
                {
                    json = WC.DownloadString(URL);
                }
                catch (HttpListenerException E)
                {
                    Console.WriteLine("Catfinder was unable to retrieve the JSON from " + URL);
                    Console.WriteLine("Error Code " + E.ErrorCode);
                    Console.WriteLine(Environment.NewLine + "press any key to exit");
                    Console.ReadKey();
                    Environment.Exit(1);
                }

                catch
                {
                    Console.WriteLine("An unknown error occoured when retrieveing the JSON body from " + URL);
                    Console.WriteLine(Environment.NewLine + "press any key to exit");
                    Console.ReadKey();
                    Environment.Exit(1);
                }
                return json;
            }
        }
    }
    
}
