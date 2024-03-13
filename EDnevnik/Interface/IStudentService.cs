using EDnevnik.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;

namespace EDnevnik.Interface
{
    public interface IStudentService
    {
   
        void CreateStudent(List<Student> students, string studString);

        void WriteAllStudents(List<Student> students);  

        Student GetStudent(List<Student> students,string name);

        bool StudentValidation( string studString);

       

    }
}
