using EDnevnik.Interface;
using EDnevnik.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDnevnik.UI
{
    public class StudentUI
    {

        private readonly IStudentService _studentService;

        public StudentUI(IStudentService studentService)
        {
            _studentService = studentService;


        }

        public void StudentMenu(List<Student> students)
        {
            Console.Clear();
            int decision = -1;
            while (decision != 5)
            {
                WriteBasicMenu();
                Console.WriteLine("Option:");
                decision = Int32.Parse(Console.ReadLine());
                switch (decision)
                {

                    case 1:
                        Console.WriteLine("Enter new students sparated by a comma and a space!");
                        string studentString = Console.ReadLine();

                        if (!_studentService.StudentValidation(studentString))
                        {
                            Console.WriteLine("Invalid student name input");
                            break;  
                        }

                        Student stud = _studentService.GetStudent(students, studentString);

                        if (stud != null )
                        {
                            Console.WriteLine("Student allready added");


                        }

                        _studentService.CreateStudent(students, studentString);
                        break;
                    case 2:
                        _studentService.WriteAllStudents(students);
                        break;

                    case 5:
                        Console.WriteLine("back to main menu");
                        break;
                    default:
                        Console.WriteLine("Non Existing Command!\n\n");
                        break;
                }
            }



         
            Console.WriteLine("Press anything...");
            Console.ReadKey(true);
        }

        public static void WriteBasicMenu()
        {
            Console.WriteLine("Edevnik : Student Menu");
            Console.WriteLine("\tOption 1: Enter new Student");
            Console.WriteLine("\tOption 2: List all Students");
            Console.WriteLine("\t\t ...");
            Console.WriteLine("\tOption 5: back to main menu");
        }
    }
}
