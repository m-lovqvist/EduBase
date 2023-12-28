using EduBase.Data;
using EduBase.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduBase.Application.ApplicationLogic
{
    internal class Course
    {
        private string connectionString = "Data Source = DESKTOP-64QT8T3; DataBase = EduBase; Trusted_connection = True; MultipleActiveResultSets = True; TrustServerCertificate=True";
        private EduBaseContext Context { get; set; }
        public Course()
        {
            Context = new();
        }
        public void CourseSummary()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Översikt: Alla kurser:");
            Console.WriteLine();

            var query = Context.Courses.ToList();

            Console.ForegroundColor = ConsoleColor.DarkGray;

            foreach (var course in query)
            {
                Console.WriteLine("Kurs-ID: {0}", course.CourseId);
                Console.WriteLine("Namn: {0}", course.Title);
                Console.WriteLine("Startdatum: {0}", course.StartDate);
                Console.WriteLine("Slutdatum: {0}", course.EndDate);
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Tryck på valfri tangent för att återgå till menyn");
            Console.ReadKey();
        }
        public void ActiveCourses()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Visar aktiva kurser:");
            Console.WriteLine();
 
            var query = from course in Context.Courses
                        join enrollment in Context.Enrollments on course.CourseId equals enrollment.FkcourseId
                        join employee in Context.Employees on course.FkemployeeId equals employee.EmployeeId
                        join student in Context.Students on enrollment.FkstudentId equals student.StudentId
                        join schoolClass in Context.SchoolClasses on student.FkclassId equals schoolClass.ClassId
                        where enrollment.SetDate == null
                        group new { course, employee, schoolClass } by new { course.Title, employee.FirstName, employee.LastName, schoolClass.Name } into g
                        select new
                        {
                            Kurs = g.Key.Title,
                            Lärare = g.Key.FirstName + " " + g.Key.LastName,
                            Klass = g.Key.Name
                        };

            Console.ForegroundColor = ConsoleColor.DarkGray;

            foreach (var result in query)
            {
                Console.WriteLine("Aktiv kurs: {0}", result.Kurs);
                Console.WriteLine("Ansvarig lärare: {0}", result.Lärare);
                Console.WriteLine("Klass: {0}", result.Klass);
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Tryck på valfri tangent för att återgå till menyn");
            Console.ReadKey();
        }
        public void ShowGrade()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Visar betyg:");
            Console.WriteLine();

            var query = from course in Context.Courses
                        join enrollment in Context.Enrollments on course.CourseId equals enrollment.FkcourseId
                        join employee in Context.Employees on course.FkemployeeId equals employee.EmployeeId
                        join student in Context.Students on enrollment.FkstudentId equals student.StudentId
                        where enrollment.SetDate != null
                        select new
                        {
                            Kurs = course.Title,
                            Elev = student.FirstName + " " + student.LastName,
                            Betyg = enrollment.Grade,
                            Lärare = employee.FirstName + " " + employee.LastName,
                            Datum = enrollment.SetDate
                        };

            Console.ForegroundColor = ConsoleColor.DarkGray;

            foreach (var item in query)
            {
                Console.WriteLine("Kurs: {0}", item.Kurs);
                Console.WriteLine("Elev: {0}", item.Elev);
                Console.WriteLine("Betyg: {0}", item.Betyg);
                Console.WriteLine("Ansvarig lärare: {0}", item.Lärare);
                Console.WriteLine("Datum: {0}", item.Datum);
                Console.WriteLine();
            }   
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Tryck på valfri tangent för att återgå till menyn");
            Console.ReadKey();
        }
        public void SetGrade() 
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Ange betyg");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            string grade = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Ange elevens ID:");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            int studentId = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Ange kursens ID");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            int courseId = int.Parse(Console.ReadLine());

            string updateStatement = "UPDATE Enrollments SET Grade = @Grade WHERE FKStudentID = @FKStudentID AND FKCourseID = @FKCourseID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(updateStatement, connection))
                {
                    command.Parameters.AddWithValue("@Grade", grade);
                    command.Parameters.AddWithValue("@FKStudentID", studentId);
                    command.Parameters.AddWithValue("@FKCourseID", courseId);

                    int result = command.ExecuteNonQuery();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    if (result < 1)
                    {
                        Console.WriteLine("Fel inmatning");
                    }
                    else
                    {
                        Console.WriteLine("Nytt betyg har lagts till i databasen");
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Tryck på valfri tangent för att återgå till menyn");
            Console.ReadKey();
        }
    }
}

