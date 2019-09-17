using System;
using System.Collections;
namespace CatFinder
{
    public class Owner
    {
        private string Name;
        private string Gender;
        private string Age;
        private Pets[] Pets;

       

        public Owner(string name, string gender, string age, Pets[] pets)
        {
            //Pets = new CatFinder.Pets[0];
            Name = name;
            Gender = gender;
            Age = age;
            Pets = pets;
        }

        public string getAge
        {
            get
            {
                return Age;
            }
        }
        public string getGender
        {
            get
            {
                return Gender;
            }
        }
        public string getName
        {
            get
            {
                return Name;
            }
        }
        public Pets[] getPets
        {
            get
            {
                return Pets;
            }
        }

    }
}
