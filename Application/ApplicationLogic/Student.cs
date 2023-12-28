using EduBase.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduBase.Application.ApplicationLogic
{
    internal class Student
    {
        private string connectionString = "Data Source = DESKTOP-64QT8T3; DataBase = EduBase; Trusted_connection = True; MultipleActiveResultSets = True; TrustServerCertificate=True";
        private EduBaseContext Context { get; set; }
        public Student()
        {
            Context = new();
        }

        public void StudentSummary()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Översikt: Alla elever:");
            Console.WriteLine();

            var query = from student in Context.Students
                        join schoolClass in Context.SchoolClasses
                        on student.FkclassId equals schoolClass.ClassId
                        select new
                        {
                            Elev_ID = student.StudentId,
                            Klass = schoolClass.Name,
                            Namn = student.FirstName + " " + student.LastName,
                            Personnummer = student.SocialSecurityNumber,
                            Adress = student.Address + " " + student.Zip
                        };

            Console.ForegroundColor = ConsoleColor.DarkGray;

            foreach (var student in query)
            {
                Console.WriteLine("Elev-ID: {0}", student.Elev_ID);
                Console.WriteLine("Klass: {0}", student.Klass);
                Console.WriteLine("Elev: {0}", student.Namn);
                Console.WriteLine("Personnummer: {0}", student.Personnummer);
                Console.WriteLine("Address: {0}", student.Adress);
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Tryck på valfri tangent för att återgå till menyn");
            Console.ReadKey();
        }
        public void NewStudent()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Ange elevens ID:");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            string studentId = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Ange förnamn:");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            string firstName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Ange efternamn");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            string lastName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Ange personnummer (YYYYMMDD-XXXX):");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            string socialSecurityNumber = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Ange adress:");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            string address = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Ange postnummer:");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            string zip = Console.ReadLine();
            Console.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Students (StudentID, FirstName, LastName, SocialSecurityNumber, Address, Zip) VALUES (@StudentID, @FirstName, @LastName, @SocialSecurityNumber, @Address, @Zip)";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@StudentID", studentId);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@SocialSecurityNumber", socialSecurityNumber);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@Zip", zip);

                    int result = command.ExecuteNonQuery();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    if (result < 1)
                    {
                        Console.WriteLine("Fel inmatning");
                    }
                    else
                    {
                        Console.WriteLine("Ny elev har lagts till i databasen");
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Tryck på valfri tangent för att återgå till menyn");
            Console.ReadKey();
        }
    }
}
