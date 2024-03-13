using EDnevnik.Interface;
using EDnevnik.Model;
using EDnevnik.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EDnevnik
{
    internal class Program
    {
        public static List<Student> students = new List<Student>();

        private static List<Grades> grades = new List<Grades>();
        static void Main(string[] args)
        {

            List<Course> courses = new List<Course>()
             {
              new Course() { Name="Biology"},
              new Course() { Name="Math"},
              new Course() { Name="Algebra"},
              new Course() { Name="English"},

             };
          

            Student student = new Student();
            student.Name =("a");
            students.Add(student);
          
            List<int> testGrades = new List<int>() { 1, 2, 3 };
           
            Grades baseGrade = new Grades();    
            baseGrade.Student = student;
            baseGrade.Course = courses[0];
            baseGrade.CourseGrades = testGrades;
            
            grades.Add(baseGrade);

            IStudentService studentService = new StudentService();
            ICourseService course = new Course();
            IGradeService gradeservice = new GradeService();

            StudentUI StudentUI = new StudentUI(studentService);
            GradeUI GradeUI = new GradeUI(studentService,gradeservice);
            GradeStatisUI GradeStatisUI = new GradeStatisUI(gradeservice,studentService);
            

         


            int decision = -1;
            while (decision != 5)
            {
                WriteBasicMenu();
                Console.WriteLine("Option:");
                decision = Int32.Parse(Console.ReadLine());
                switch (decision)
                {

                    case 1:
                        course.WriteCourses(courses);
                        break;
                    case 2:
                        StudentUI.StudentMenu(students);
                        break;
                    case 3:
                        GradeUI.GradeMenu(students, courses, grades);
                        break;
                    case 4:
                        GradeStatisUI.GradeMenu(courses, grades,students);
                        break;
                    case 5:
                        Console.WriteLine("Exit The Program");
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
            Console.WriteLine("Edevnik : basic menu");
            Console.WriteLine("\tOption 1: View all courses");
            Console.WriteLine("\tOption 2: Enter new student");
            Console.WriteLine("\tOption 3: Enter a grade for a student and course");
            Console.WriteLine("\tOption 4: Student statistics");
            Console.WriteLine("\t\t ...");
            Console.WriteLine("\tOption 5:Exit the program");
        }
    }
}