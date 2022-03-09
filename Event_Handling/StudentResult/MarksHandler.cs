using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentResult
{
    public delegate void Fail();
    public delegate void Pass(int mark);
   public class MarksHandler
    {
        public static void ShowResult(int mark)
        {
            Console.WriteLine("You are passed with marks : "+ mark);
        }

        public static void Failed()
        {
            Console.WriteLine("You can't scored above 40 marks");
        }
    }
}
