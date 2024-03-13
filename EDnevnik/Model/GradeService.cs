using EDnevnik.Interface;
using EDnevnik.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EDnevnik.Model
{
    public class GradeService : IGradeService
    {
        public string AddGradeComment(int grade)
        {
            string gradeWithComment = "";

            switch (grade)
            {
                case 1:
                    gradeWithComment += grade + " :Failed";
                    break;
                case 2:
                    gradeWithComment += grade + " :Enough";
                    break;
                case 3:
                    gradeWithComment += grade + " :Good";
                    break;
                case 4:
                    gradeWithComment += grade + " :Very Good";
                    break;
                case 5:
                    gradeWithComment += grade + " :Exalted";
                    break;

            }
            return gradeWithComment;
        }

        public List<string> DoesntHaveGrade(List<Grades> graded, List<Course> course)
        {
            List<string> hasGradesList = graded.Select(s => s.Course.Name).ToList();

            List<string> allCourses = course.Select(s => s.Name).ToList();

            return allCourses.Except(hasGradesList).ToList();

        }



        public List<Grades> FindByStudentName(List<Grades> grades, string studentName)
        {
            var item = grades.Where(s => s.Student.Name == studentName).ToList();
            return item;
        }



        public Grades FindOneByStudenName(string studenName, List<Grades> grades, string courseName)
        {
            return grades.Where(s => s.Student.Name == studenName && s.Course.Name == courseName).FirstOrDefault();
        }

        public void ListFormatedGrades(List<int> grades)
        {
            string formatedGrade = "Grades:  [";


            for (int i = 0; i < grades.Count; i++)
            {



                if (i == grades.Count - 1)
                {
                    formatedGrade += ($"{AddGradeComment(grades[i])} ]");
                }
                else
                {
                    formatedGrade += ($"{AddGradeComment(grades[i])} ,");
                }

            }
            Console.WriteLine(formatedGrade);

            foreach (int grade in grades)
            {


                formatedGrade.Concat(grade + ", ");
            }
        }



        public bool ValidateGrateInput(int grade)
        {

            bool isValid = false;

            if (grade >= 1 && grade <= 5)
            {
                isValid = true;
            }
            return isValid;
        }

        public void WriteGrade(Grades grade)
        {


     
            Console.WriteLine("Course Name:    - " + grade.Course.Name);


            ListFormatedGrades(grade.CourseGrades);
            Console.WriteLine("Average : " +
                (AddGradeComment((int)grade.CourseGrades.Average())));


        }


    }
}

