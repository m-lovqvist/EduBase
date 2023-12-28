using EduBase.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduBase.Application.ApplicationLogic
{
    internal class Department
    {
        private EduBaseContext Context { get; set; }
        public Department()
        {
            Context = new();
        }
        public void DepartmentSummary()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Översikt: Alla avdelningar:");
            Console.WriteLine();

            var query = from employee in Context.Employees
                        join department in Context.Departments
                        on employee.FkdepartmentId equals department.DepartmentId
                        group employee by department.Name into g
                        select new
                        {
                            Avdelning = g.Key,
                            Anställda = g.Count()
                        };


            Console.ForegroundColor = ConsoleColor.DarkGray;

            foreach (var item in query)
            {
                Console.WriteLine("Namn: {0}", item.Avdelning);
                Console.WriteLine("Antal anställda: {0}", item.Anställda);
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Tryck på valfri tangent för att återgå till menyn");
            Console.ReadKey();
        }
        public void TeachersPerDepartment()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Antal lärare per avdelning:");
            Console.WriteLine();

            var query = from employee in Context.Employees
                        join department in Context.Departments on employee.FkdepartmentId equals department.DepartmentId
                        where employee.FkprofessionId == 3
                        group employee by department.Name into g
                        select new
                        {
                            Avdelning = g.Key,
                            Lärare = g.Count()
                        };

            Console.ForegroundColor = ConsoleColor.DarkGray;

            foreach (var item in query)
            {
                Console.WriteLine("Namn: {0}", item.Avdelning);
                Console.WriteLine("Antal lärare: {0}", item.Lärare);
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Tryck på valfri tangent för att återgå till menyn");
            Console.ReadKey();
        }
    }
}
