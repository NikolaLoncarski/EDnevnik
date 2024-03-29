﻿using EDnevnik.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDnevnik.Model
{
    public class CourseService : ICourseService
    {
        public Course GetCoourse(string name, List<Course> courses)
        {
            Course item = courses.SingleOrDefault(s => s.Name == name);
            return item;
        }

        public void WriteCourses(List<Course> courses)
        {
            foreach (Course course in courses)
            {

                Console.WriteLine("Course Name :   - " + course.Name);
            }
        }
    }
}
