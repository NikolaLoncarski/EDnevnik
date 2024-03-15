using EDnevnik.Interface;
using EDnevnik.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDnevnik.UI
{
 public class GradeUI
    {
        private readonly IStudentService _studentService;
        private readonly IGradeService _gradeService;
        private readonly ICourseService _courseService;


   
        
        public GradeUI(IStudentService studentService,IGradeService gradeService,ICourseService courseService)
        {
            _studentService = studentService;
            _gradeService = gradeService;
            _courseService = courseService;


        }

        public  void GradeMenu(List<Student> students, List<Course> courses, List<Grades> grades)
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




                      var student =  _studentService.GetStudent(students, studentName);
                      if (student == null )
                        {
                            Console.WriteLine("No Student with that name exists");
                            break;
                        }

                       

                        Console.WriteLine("Please enter Course Name");
                        string courseName = Console.ReadLine();

                        var course = _courseService.GetCoourse(courseName, courses);
                        if (course == null)
                        {
                            Console.WriteLine("No Course with that name exists");
                            break;
                        }
                        Console.WriteLine("Please enter Grade");
                        int gradeNumb = int.Parse(Console.ReadLine());

                        if (!_gradeService.ValidateGrateInput(gradeNumb))
                        {
                            Console.WriteLine("Grade Must be between 1-5;");
                            break;
                        }
                        Grades oldGrade = _gradeService.FindOneByStudenName(studentName, grades, courseName);

                        if (oldGrade == null)
                        {
                            Grades grade = new Grades();
                            grade.Student = student;
                            grade.Course = course;
                            grade.CourseGrades.Add(gradeNumb);
                            grades.Add(grade);
                        } else
                        {
                            oldGrade.CourseGrades.Add(gradeNumb);
                     
                        }
                       
                    
                        Console.WriteLine("Grade sucessfully added!");
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
            Console.WriteLine("Edevnik : Grade Menu");
            Console.WriteLine("\tOption 1:Add Grade");
          
            Console.WriteLine("\t\t ...");
            Console.WriteLine("\tOption 5:back to main menu");
        }
    }
}
