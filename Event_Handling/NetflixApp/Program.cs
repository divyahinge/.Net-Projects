using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixApp
{
    class Program
    {
        static void Main(string[] args)
        {
           // Registration register = new Registration("Divya" ,23);
            


            //register.adults += new Movies(DetailsHandler.ShowMovieList);
            //register.childrens += new Anime(Animation.ShowAnime);

            //register.ShowList();
            Console.WriteLine("----------------------------------------------");

            Registration reg = new Registration("Diya", 19);
            reg.adults += new Movies(DetailsHandler.ShowMovieList);
            reg.childrens += new Anime(Animation.ShowAnime);

            reg.ShowList();
            Console.ReadLine();
        }
    }
}
