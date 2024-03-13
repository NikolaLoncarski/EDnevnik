using EDnevnik.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDnevnik.Interface
{
    public interface IGradeService
    {

        List<Grades> FindByStudentName(List<Grades> grades, string studentName);
        void WriteGrade(Grades grades);

        void ListFormatedGrades(List<int> grades);
        string AddGradeComment(int grade);
        bool ValidateGrateInput(int grade);

        Grades FindOneByStudenName(string studenName, List<Grades> grades, string courseName);
        List<string> DoesntHaveGrade(List<Grades> grades, List<Course> course);






    }
}
