using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduBase.Application.ApplicationLogic.MenuLogic
{
    internal class Menu
    {
        private string[] empOptions = { "[1] Översikt: All personal\t\t", "[2] Registrera ny personal\t\t", "[3] Tillbaka till huvudmenyn\t\t" };
        private int empSelected = 0;
        private string[] studOptions = { "[1] Översikt: Alla elever\t\t", "[2] Registrera ny elev\t\t", "[3] Tillbaka till huvudmenyn\t\t" };
        private int studSelected = 0;
        private string[] courOptions = { "[1] Översikt: Alla kurser\t\t", "[2] Översikt: Aktiva kurser\t\t", "[3] Visa betyg\t\t", "[4] Registrera betyg", "[5] Tillbaka till huvudmenyn\t\t" };
        private int courSelected = 0;
        private string[] depOptions = { "[1] Översikt: Alla avdelningar\t\t", "[2] Löner\t\t", "[3] Översikt: Antal lärare per avdelning\t\t", "[4] Tillbaka till huvudmenyn\t\t" };
        private int depSelected = 0;
        private string[] salOptions = { "[1] Lön per avdelning\t\t", "[2] Medellön per avdelning\t\t", "[3] Tillbaka till huvudmenyn\t\t" };
        private int salSelected = 0;
        public void EmployeeMenu()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("EduBase Personal");
                Console.WriteLine();
                Console.ResetColor();
                Console.WriteLine("\x1b[?25l");

                for (int i = 0; i < empOptions.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    if (i == empSelected)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(empOptions[i] + "<--");
                    }
                    else
                    {
                        Console.WriteLine(empOptions[i]);
                    }
                    Console.ResetColor();
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.DownArrow && empSelected + 1 != empOptions.Length)
                {
                    empSelected++;
                }
                else if (keyPressed == ConsoleKey.UpArrow && empSelected != 0)
                {
                    empSelected--;
                }
                else if (keyPressed == ConsoleKey.Enter)
                {
                    switch (empSelected)
                    {
                        case 0:
                            new Employee().EmployeeSummary();
                            break;
                        case 1:
                            new Employee().NewEmployee();
                            break;
                        case 2:
                            ReturnToMainMenu();
                            break;
                        default:
                            Console.WriteLine("Välj vad du vill göra");
                            break;
                    }

                    Console.CursorVisible = true;

                    break;
                }
            }
            EmployeeMenu();
        }

        public void StudentMenu()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("EduBase Elever");
                Console.WriteLine();
                Console.ResetColor();
                Console.WriteLine("\x1b[?25l");

                for (int i = 0; i < studOptions.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    if (i == studSelected)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(studOptions[i] + "<--");
                    }
                    else
                    {
                        Console.WriteLine(studOptions[i]);
                    }
                    Console.ResetColor();
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.DownArrow && studSelected + 1 != studOptions.Length)
                {
                    studSelected++;
                }
                else if (keyPressed == ConsoleKey.UpArrow && studSelected != 0)
                {
                    studSelected--;
                }
                else if (keyPressed == ConsoleKey.Enter)
                {
                    switch (studSelected)
                    {
                        case 0:
                            new Student().StudentSummary();
                            break;
                        case 1:
                            new Student().NewStudent();
                            break;
                        case 2:
                            ReturnToMainMenu();
                            break;
                        default:
                            Console.WriteLine("Välj vad du vill göra");
                            break;
                    }

                    Console.CursorVisible = true;

                    break;
                }
            }
            StudentMenu();
        }

        public void CourseMenu()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("EduBase Kurser");
                Console.WriteLine();
                Console.ResetColor();
                Console.WriteLine("\x1b[?25l");

                for (int i = 0; i < courOptions.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    if (i == courSelected)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(courOptions[i] + "<--");
                    }
                    else
                    {
                        Console.WriteLine(courOptions[i]);
                    }
                    Console.ResetColor();
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.DownArrow && courSelected + 1 != courOptions.Length)
                {
                    courSelected++;
                }
                else if (keyPressed == ConsoleKey.UpArrow && courSelected != 0)
                {
                    courSelected--;
                }
                else if (keyPressed == ConsoleKey.Enter)
                {
                    switch (courSelected)
                    {
                        case 0:
                            new Course().CourseSummary();
                            break;
                        case 1:
                            new Course().ActiveCourses();
                            break;
                        case 2:
                            new Course().ShowGrade();
                            break;
                        case 3:
                            new Course().SetGrade();
                            break;
                        case 4:
                            ReturnToMainMenu();
                            break;
                        default:
                            Console.WriteLine("Välj vad du vill göra");
                            break;
                    }

                    Console.CursorVisible = true;

                    break;
                }
            }
            CourseMenu();
        }

        public void DepartmentMenu()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("EduBase Avdelningar");
                Console.WriteLine();
                Console.ResetColor();
                Console.WriteLine("\x1b[?25l");

                for (int i = 0; i < depOptions.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    if (i == depSelected)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(depOptions[i] + "<--");
                    }
                    else
                    {
                        Console.WriteLine(depOptions[i]);
                    }
                    Console.ResetColor();
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.DownArrow && depSelected + 1 != depOptions.Length)
                {
                    depSelected++;
                }
                else if (keyPressed == ConsoleKey.UpArrow && depSelected != 0)
                {
                    depSelected--;
                }
                else if (keyPressed == ConsoleKey.Enter)
                {
                    switch (depSelected)
                    {
                        case 0:
                            new Department().DepartmentSummary();
                            break;
                        case 1:
                            SalaryMenu();
                            break;
                        case 2:
                            new Department().TeachersPerDepartment();
                            break;
                        case 3:
                            ReturnToMainMenu();
                            break;
                        default:
                            Console.WriteLine("Välj vad du vill göra");
                            break;
                    }

                    Console.CursorVisible = true;

                    break;
                }
            }
            DepartmentMenu();
        }

        public void SalaryMenu()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("EduBase Löner");
                Console.WriteLine();
                Console.ResetColor();
                Console.WriteLine("\x1b[?25l");

                for (int i = 0; i < salOptions.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    if (i == salSelected)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(salOptions[i] + "<--");
                    }
                    else
                    {
                        Console.WriteLine(salOptions[i]);
                    }
                    Console.ResetColor();
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.DownArrow && salSelected + 1 != salOptions.Length)
                {
                    salSelected++;
                }
                else if (keyPressed == ConsoleKey.UpArrow && salSelected != 0)
                {
                    salSelected--;
                }
                else if (keyPressed == ConsoleKey.Enter)
                {
                    switch (salSelected)
                    {
                        case 0:
                            new Salary().SalaryPerDepartment();
                            break;
                        case 1:
                            new Salary().AverageSalary();
                            break;
                        case 2:
                            ReturnToMainMenu();
                            break;
                        default:
                            Console.WriteLine("Välj vad du vill göra");
                            break;
                    }

                    Console.CursorVisible = true;

                    break;
                }
            }
            SalaryMenu();
        }
        public void ReturnToMainMenu()
        {
            new App().RunMenu();
        }
    }
}
