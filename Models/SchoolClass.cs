using System;
using System.Collections.Generic;

namespace EduBase.Models;

public partial class SchoolClass
{
    public int ClassId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
