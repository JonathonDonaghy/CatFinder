using System;
namespace CatFinder
{
    public class Pets
    {
        private string Name;
        private string Type;



        public Pets(string name, string type)
        {
            Name = name;
            Type = type;
            //throw new NotImplementedException("nyi");
        }

        public string getType
        {
            get
            {
                return Type;
            }
        }
        public string getName
        {
            get
            {
                return Name;
            }
        }
    }
}
