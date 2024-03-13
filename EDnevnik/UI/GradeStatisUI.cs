using EDnevnik.Interface;
using EDnevnik.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDnevnik.UI
{
    public class GradeStatisUI
    {
        private readonly IGradeService _gradeService;


        private IStudentService _studentService;

        

        public GradeStatisUI(IGradeService gradeService, IStudentService studentService)
        {
            _gradeService = gradeService;
            _studentService = studentService;
        }

        public void GradeMenu(List<Course> courses, List<Grades> grades ,List<Student> students)
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
                        Console.WriteLine("Enter students full name");

                        string studentName = Console.ReadLine();

                        var student = _studentService.GetStudent(students, studentName);
                        if (student == null)
                        {
                            Console.WriteLine("No Student with that name exists");
                            break;
                        }
                        List<Grades> studentGradeList =  _gradeService.FindByStudentName(grades, studentName);
                        Console.WriteLine("Student Name:    - " + studentGradeList[0].Student.Name);
                      

                        foreach (var gradeItem in studentGradeList)
                        {
                            
                            Grades studentGrade = new Grades();
                            studentGrade.Student = gradeItem.Student;
                            studentGrade.Course= gradeItem.Course;
                            studentGrade.CourseGrades = gradeItem.CourseGrades;
                            
                            
                            _gradeService.WriteGrade(studentGrade);
                        }
                      

                      List<string> doesntHaveGrade = _gradeService.DoesntHaveGrade(grades, courses);
                        foreach(var grade in doesntHaveGrade)
                        {
                            Console.WriteLine(grade + ": Not graded yet");

                        }

                        break;
                    case 5:
                        Console.WriteLine("back to main menu");
                        break;
                    default:
                        Console.WriteLine("Non Existing Command!\n\n");
                        break;
                }
            }


            Console.Clear();

            Console.WriteLine("Press anything...");
            Console.ReadKey(true);
        }

        public static void WriteBasicMenu()
        {
            Console.WriteLine("Edevnik : Grade Statistics");
            Console.WriteLine("\tOption 1:Find Grades by student name");

            Console.WriteLine("\t\t ...");
            Console.WriteLine("\tOption 5:back to main menu");
        }
    }
}
