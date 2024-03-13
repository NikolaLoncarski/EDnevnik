using EDnevnik.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDnevnik.Interface
{
  public interface ICourseService
    {

        void WriteCourses(List<Course> courses);

        Course GetCoourse(string name, List<Course> courses);

       
    }
}
