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
            JArray owners = JArray.Parse(json);
            //JToken results = owners["gender"]; 
            OrderedDictionary cats = new OrderedDictionary();

            //adding manually to ensure males are listed first as per requirements
            cats.Add("Male", new ArrayList());
            cats.Add("Female", new ArrayList());
            /*
            var bats = from owner in owners
                       group owner by owner["gender"]
                       into gender
                       where gender.Values("pets").Count() > 0
                       //orderby gender descending
                       select new { bat = gender.Values<string>("gender"), pets =
                                from pet in gender.Values("pets")
                                    //group pet by pet["type"]
                                    //into types
                                where pet.Values("type").Count() > 0 
                                //where pet.Values("type").Equals("Cat")
                                select new {name = pet.Values("name").First() }
                       };

            Console.WriteLine(bats.ToString());
            Console.WriteLine(bats);
            Console.WriteLine(bats.ElementAt(0).bat.First());
            foreach(var bat in bats)
            {
                Console.WriteLine(bat.bat.First());
                foreach(var cat in bat.pets)
                {
                    //Console.WriteLine(cat);
                    Console.WriteLine(cat.name);
                    

                }
            }
            Console.ReadKey();
            */

            //parse json into cats dictionary
            foreach(JObject owner in owners)
            {
                string gender = owner["gender"].Value<string>();
                if (!cats.Contains(gender))
                {
                    cats.Add(gender, new ArrayList());
                }
                foreach(JToken pet in owner["pets"])
                if (pet["type"].Value<string>() == "Cat") {
                    ((ArrayList)cats[gender]).Add(pet["name"].ToString());
                }
            }
            foreach (DictionaryEntry catList in cats)
            {
                ((ArrayList)catList.Value).Sort(); //will sort alpabetically
            }


            return cats;
        }


    }
}
