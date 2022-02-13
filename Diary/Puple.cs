using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary
{
    internal class Puple
    {
        public Puple(string Name, string Surname, int Age, string Class)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Age = Age;
            this.Class = Class;
            Grades = new List<int>();
        }
        public string Name;
        public string Surname;
        public int Age;
        public string Class;
        public const string UserType = "puple";

        public List<int> Grades;
    }
}
