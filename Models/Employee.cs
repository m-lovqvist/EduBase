using System;
using System.Collections.Generic;

namespace EduBase.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? SocialSecurityNumber { get; set; }

    public string? HireDate { get; set; }

    public decimal? Salary { get; set; }

    public string? Address { get; set; }

    public string? Zip { get; set; }

    public int? FkprofessionId { get; set; }

    public int? FkdepartmentId { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual Department? Fkdepartment { get; set; }

    public virtual Profession? Fkprofession { get; set; }
}
