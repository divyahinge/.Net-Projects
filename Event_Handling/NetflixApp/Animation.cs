using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixApp
{
    public delegate void Anime();
    public class Animation
    {
        public static void ShowAnime()
        {
            Console.WriteLine("Which type of anime u want to see :\n1.Shows \n2.Movies");
            int op = int.Parse(Console.ReadLine());
            Console.WriteLine("----------------------------------------------");

            switch(op)
            {
                case 1:
                    Console.WriteLine("*************LIST**************************");
                    Console.WriteLine("Tom n Jerry");
                    Console.WriteLine("Attack on Titan");
                    Console.WriteLine("Death Note");
                    Console.WriteLine("Beastars");
                    break;

                case 2:
                    Console.WriteLine("*************LIST**************************");
                    Console.WriteLine("Pokemon");
                    Console.WriteLine("Stand by me Doraemon");
                    Console.WriteLine("Silent Voice");
                    Console.WriteLine("Modest Heroes");
                    break;
            }
        }
    }
}
