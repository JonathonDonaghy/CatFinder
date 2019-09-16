using System;
using System.Collections;
namespace CatFinder
{
    public static class ExtractCats
    {
        //extracts cats into cat dictionary that uses the owners gender as a key
        public static void ExtractCatsFromOwners()
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
        }


    }
}
