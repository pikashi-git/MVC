using MVC網站.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC網站.DAL
{
    public class SchoolInitializer :
    //DropCreateDatabaseAlways<SchoolContext>
    /*CreateDatabaseIfNotExists<SchoolContext>*/
    DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            base.Seed(context);

            var students = new List<Student>
            {
                new Student
                {
                    StudentID="S001",
                    StudentName="S001_name",
                    Gender=false,
                    Birthday=Convert.ToDateTime("1988/8/8")
                },
                new Student
                {
                    StudentID="S002",
                    StudentName="S002_name",
                    Gender=true,
                    Birthday=Convert.ToDateTime("1978/7/17")
                }
            };

            var teachers = new List<Teacher>
            {
                new Teacher
                {
                    TeachID="T001",
                    TeacherName="T001_name",
                    Gender=false,
                    Birthday=Convert.ToDateTime("1988/8/8")
                },
                new Teacher
                {
                    TeachID="T002",
                    TeacherName="T002_name",
                    Gender=true,
                    Birthday=Convert.ToDateTime("1978/7/17")
                }
            };

            students.ForEach(student => context.Students.Add(student));
            teachers.ForEach(teacher => context.Teachers.Add(teacher));
            context.SaveChanges();
        }
    }
}