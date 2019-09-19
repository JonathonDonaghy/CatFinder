using System;
using System.Collections;
using Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace CatFinder
{
    public class ExtractCats
    {
        //extracts cats into cat dictionary that uses the owners gender as a key
       /* public void extractCatsFromOwners()
        {
            //loop through all owners in the owners array (generated from the JSON file)
            for (int i = 0; i < Globals.owners.Length; i++)
            {
                //check for and skip null owner or pets
                if (Globals.owners[i] == null || Globals.owners[i].getPets == null) continue;
                string gender = Globals.owners[i].getGender;
                //if the dictionary doesn't have a gender key yet, create one.
                if (!Globals.cats.ContainsKey(gender))
                {
                    Globals.cats.Add(gender, new ArrayList());
                }

                foreach (Pets pet in Globals.owners[i].getPets)
                {
                    //only adding pets of type "Cat"
                    if (pet.getType == "Cat")
                    {
                        //if the dictionary doesn't have a gender key yet, create one. 

                        
                        ((ArrayList)Globals.cats[gender]).Add(pet.getName);
                    }
                }
                
            }
            foreach(DictionaryEntry catList in Globals.cats)
            {
                ((ArrayList)catList.Value).Sort(); //will sort alpabetically
            }
        }*/

        public Hashtable ExtractCatsFromJson(string json)
        {
            JArray owners = JArray.Parse(json);
            //JToken results = owners["gender"]; 

            Hashtable cats = new Hashtable();

            //adding manually to ensure males are listed first as per requirements
            cats.Add("Male", new ArrayList());
            cats.Add("Female", new ArrayList());

            //parse json into cats dictionary
            foreach(JObject owner in owners)
            {
                string gender = owner["gender"].Value<string>();
                if (!cats.ContainsKey(gender))
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
