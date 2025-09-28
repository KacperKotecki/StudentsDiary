using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDiary
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstNAme { get; set; }

        public string LastName { get; set; }

        public List<Grade> Grades { get; set; }
        public string Pesel { get; set; }

        public string IndexNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Student()
        {
            Grades = new List<Grade>();
        }

        public override string ToString()
        {
            return $"{Id}. {FirstNAme} {LastName}";
        }
    }
    
}
