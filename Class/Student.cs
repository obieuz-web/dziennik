using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dziennik.Class
{
    internal class Student
    {
        public int PESEL { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string klasa { get; set; }
        public int punkty { get; set; }
        public List<Grade> oceny { get; set; }

        public Student()
        { }

    }
}
