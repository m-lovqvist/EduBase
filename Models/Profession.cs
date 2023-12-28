using System;
using System.Collections.Generic;

namespace EduBase.Models;

public partial class Profession
{
    public int ProfessionId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
