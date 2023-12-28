using System;
using System.Collections.Generic;

namespace EduBase.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string? Title { get; set; }

    public string? StartDate { get; set; }

    public string? EndDate { get; set; }

    public int? FkemployeeId { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual Employee? Fkemployee { get; set; }
}
