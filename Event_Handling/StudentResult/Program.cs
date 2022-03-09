using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentResult
{
    class Program
    {
        static void Main(string[] args)
        {
            //Student stud = new Student("Divya", 45);
            //Student stud = new Student("Divya", 38);

            Student stud = new Student();
            Console.WriteLine("Enter student name :");
            string name = Console.ReadLine();

            Console.WriteLine("\nEnter student marks :");
            int mark = int.Parse(Console.ReadLine());

            stud.Name = name;
            stud.Marks = mark;

            stud.OnPass += new Pass(MarksHandler.ShowResult);
            stud.OnFail += new Fail(MarksHandler.Failed);

            stud.Result(stud.Marks);
            Console.ReadLine();
        }
    }
}
