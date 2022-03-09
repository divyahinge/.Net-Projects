using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentResult
{
    public class Student
    {
        public event Pass OnPass;
        public event Fail OnFail;

        public string Name { get; set; }

        public int Marks { get; set; }

       /* public int Marks
        {
            get { return this.marks; }
            set
            {
                if (marks > 40)
                    OnPass(marks);
                else
                    OnFail();
            }
        }
*/

        public Student() { }

        public Student(string nm, int marks)
        {
            Name = nm;
            Marks = marks;
        }

        public void Result(int marks)
        {
            if (marks > 40)
                OnPass(marks);
            else
                OnFail();
        }
    }
}
