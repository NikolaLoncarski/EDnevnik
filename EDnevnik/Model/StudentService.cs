using EDnevnik.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDnevnik.Model
{
    public class StudentService : IStudentService
    {


        public void CreateStudent(List<Student> students, string studString)
        {



            List<string> nameList = studString.Split(',').Select(sValue => sValue.Trim()).ToList();

            foreach (var names in nameList)
            {
                Student item = new Student(names.ToLower());

                students.Add(item);
            }

            Console.WriteLine("Students Succesfully created");
        }

        public Student GetStudent(List<Student> students, string name)
        {

            Student item = students.SingleOrDefault(s => s.Name == name);
            return item;
        }

        public bool StudentValidation(string studString)
        {

            bool isNotValid = true;
            List<string> nameList = studString.Split(',').Select(sValue => sValue.Trim()).ToList();

            foreach (var names in nameList)
            {
                List<string> validNames = names.Split(' ').ToList();
                if (validNames.Count > 2)
                {
                    isNotValid = false;
                    break;
                }
            }

            return isNotValid;
        }

        public void WriteAllStudents(List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine("Student    -   "  +student.Name);
            }
        }
    }
}
