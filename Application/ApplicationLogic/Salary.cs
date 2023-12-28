using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduBase.Application.ApplicationLogic
{
    internal class Salary
    {
        private string connectionString = "Data Source = DESKTOP-64QT8T3; DataBase = EduBase; Trusted_connection = True; MultipleActiveResultSets = True; TrustServerCertificate=True";
        public void SalaryPerDepartment()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Visar total månadsutbetalning av lön per avdelning");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT Departments.Name AS 'Avdelning', SUM(Employees.Salary) AS 'Total månadsutbetalning av löner' FROM Employees\r\nJOIN Departments ON Employees.FKDepartmentID = Departments.DepartmentID\r\nGROUP BY Departments.Name", connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string department = reader.GetString(0);
                            decimal totalSalary = reader.GetDecimal(1);

                            Console.WriteLine("Avdelning: {0}", department);
                            Console.WriteLine("Total månadsutbetalning av löner: {0}", totalSalary);
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
        public void AverageSalary()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Visar medellön per avdelning och månad");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT Departments.Name AS 'Avdelning', AVG(Employees.Salary) AS 'Medellön per månad' FROM Employees\r\nJOIN Departments ON DepartmentID = FKDepartmentID\r\nGROUP BY Departments.Name", connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string department = reader.GetString(0);
                            decimal averageSalary = reader.GetDecimal(1);

                            Console.WriteLine("Avdelning: {0}", department);
                            Console.WriteLine("Medellön per månad: {0}", averageSalary);
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
    }
}
