using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixApp
{
    public delegate void Movies();
    class DetailsHandler
    {
        public static void ShowMovieList()
        {
            
            Console.WriteLine("\n");
            Console.WriteLine("Which type of movie u want to see :\n1.Action Thrillers \n2.Comedy \n 3.Horror \n4.Drama");
            int op = int.Parse(Console.ReadLine());
            Console.WriteLine("------------------------------------------------------------");
            switch(op)
            {
                case 1:
                    Console.WriteLine("********Action Movies************");
                    Console.WriteLine("6 Underground");
                    Console.WriteLine("Now you see me");
                    Console.WriteLine("Sherlock Holmes");
                    Console.WriteLine("Project Power");
                    Console.WriteLine("Mission Impossible");
                    break;

                case 2:
                    Console.WriteLine("********Comedy Movies************");
                    Console.WriteLine("Red Notice");
                    Console.WriteLine("Dolittle");
                    Console.WriteLine("Ludo");
                    Console.WriteLine("Queen");
                    break;

                case 3:
                    Console.WriteLine("********Horror Movies************");
                    Console.WriteLine("Army of the Dead");
                    Console.WriteLine("Alive");
                    Console.WriteLine("The Conjuring");
                    Console.WriteLine("The Nun");
                    Console.WriteLine("Escape Room");
                    break;

                case 4:
                    Console.WriteLine("********Dramas************");
                    Console.WriteLine("The Aviator");
                    Console.WriteLine("Blue Valentine");
                    Console.WriteLine("The King's Speech");
                    break;
            }
        }
    }
}
