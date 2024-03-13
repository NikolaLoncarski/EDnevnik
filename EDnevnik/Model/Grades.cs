using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDnevnik.Model
{
    public class Grades


    {

        public Student Student { get; set; }
        public Course Course { get; set; }

        public List<int> CourseGrades = new List<int>();
    }
}
