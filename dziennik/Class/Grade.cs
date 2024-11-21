using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dziennik.Class
{
    internal class Grade
    {
        public int Id_ucznia { get; set; }
        public int ocena { get; set; }
        public int Id_przedmiotu { get; set; }
        public string nazwa { get; set; }
        public Grade() { }
    }
}
