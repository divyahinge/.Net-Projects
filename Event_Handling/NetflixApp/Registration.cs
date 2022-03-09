using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixApp
{
   public class Registration
    {

        public event Movies adults;
        public event Anime  childrens ;

        public string Name { get; set; }
        public int Age { get; set; }

        public Registration() { }
        public Registration(string nm,int a)
        {
            Name = nm;
            Age = a;
        }

        public void ShowList()
        {
            if(this.Age > 18)
            {
                Console.WriteLine("Your age is above 18");
                adults();
            }
            else
            {
                Console.WriteLine("Your age is below 18");
                childrens();
            }
        }
    }
}
