using System;
using System.Collections;
using Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Linq;
using ObjectDumping;
using System.Collections.Specialized;

namespace CatFinder
{
    public class ExtractCats
    {
        //extracts cats into cat dictionary that uses the owners gender as a key
        public OrderedDictionary ExtractCatsFromJson(string json)
        {
            //parse the json into a usable object
            JArray owners = new JArray();
            try
            {
                owners = JArray.Parse(json);
            }
            catch(JsonException)
            {
                Console.WriteLine("could not parse the JSON body. given JSON may not be valid");
                Console.WriteLine("please check the source and try again");
                Console.WriteLine("press any key to close");
                Console.ReadKey();
                Environment.Exit(1);
            }
            catch
            {
                Console.WriteLine("An unknown error occoured when trying to parse the JSON body");
                Console.WriteLine("press any key to close");
                Console.ReadKey();
                Environment.Exit(1);
            }
            
            //extract the needed infomation
            var CatFinder = from owner in owners
                       group owner by owner["gender"]
                       into gender
                       orderby gender.Values()["gender"].ToString()
                       select new { p = gender.SelectMany(t => t.Values().ElementAt(3)).OrderBy
                       (t => t["name"]).Where(t => t["type"].ToString() == "Cat") , g = gender.First()["gender"]};

            //using an orded Dictionary to ensure the correct order in the display (Male-owned cats then Female-Owned cats)  
            //as specified in the challenge.
            OrderedDictionary cats = castToOrderedDict(CatFinder.ToDictionary(x => x.g, x => x.p.ToList()));

            return cats;
        }

        private OrderedDictionary castToOrderedDict(IDictionary input)
        {
            OrderedDictionary ordered = new OrderedDictionary(input.Count);
            foreach(DictionaryEntry kvp in input)
            {
                ordered.Add(kvp.Key, kvp.Value);
            }
            return ordered;
        }


    }
}
