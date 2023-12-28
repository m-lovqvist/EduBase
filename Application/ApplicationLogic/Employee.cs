using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduBase.Application.ApplicationLogic
{
    internal class Employee
    {
        private string connectionString = "Data Source = DESKTOP-64QT8T3; DataBase = EduBase; Trusted_connection = True; MultipleActiveResultSets = True; TrustServerCertificate=True";
        public void EmployeeSummary()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Översikt: Alla anställda");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT FirstName + ' ' + LastName AS 'Namn', Professions.Name AS 'Befattning', DATEDIFF(year, HireDate, GETDATE()) AS 'Anställd antal år' FROM Employees\r\nJOIN Professions ON FKProfessionID = ProfessionID", connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader.GetString(0);
                            string position = reader.GetString(1);
                            int yearsEmployed = reader.GetInt32(2);

                            Console.WriteLine("Namn: {0}", name);
                            Console.WriteLine("Befattning: {0}", position);
                            Console.WriteLine("Anställd antal år: {0}", yearsEmployed);
                            Console.WriteLine();
                        }
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Tryck på valfri tangent för att återgå till menyn");
                        Console.ReadKey();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void NewEmployee()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Ange den anställdes ID:");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            string employeeId = Console.ReadLine();
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
            Console.WriteLine("Ange anställningsdatum (Första tre av månaden Dag År:");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            string hireDate = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Ange lön (MMMMM,0000):");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            string salary = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Ange adress:");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            string address = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Ange postnummer:");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            string zip = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Ange befattnings-ID:");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            string fkProfessionId = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Ange avdelnings-ID:");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            string fkDepartmentId = Console.ReadLine();
            Console.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Employees (EmployeeID, FirstName, LastName, SocialSecurityNumber, HireDate, Salary, Address, Zip, FKProfessionID, FKDepartmentID) VALUES (@EmployeeID, @FirstName, @LastName, @SocialSecurityNumber, @HireDate, @Salary, @Address, @Zip, @FKProfessionID, @FKDepartmentID)";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", employeeId);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@SocialSecurityNumber", socialSecurityNumber);
                    command.Parameters.AddWithValue("@HireDate", hireDate);
                    command.Parameters.AddWithValue("@Salary", salary);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@Zip", zip);
                    command.Parameters.AddWithValue("@FKProfessionID", fkProfessionId);
                    command.Parameters.AddWithValue("@FKDepartmentID", fkDepartmentId);

                    int result = command.ExecuteNonQuery();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    if (result < 1)
                    {
                        Console.WriteLine("Fel inmatning");
                    }
                    else
                    {
                        Console.WriteLine("Ny anställd har lagts till i databasen");
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Tryck på valfri tangent för att återgå till menyn");
        }
    }
}
