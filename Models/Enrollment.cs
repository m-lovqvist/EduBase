using System;
using System.Collections.Generic;

namespace EduBase.Models;

public partial class Enrollment
{
    public int EnrollmentId { get; set; }

    public string? Grade { get; set; }

    public string? SetDate { get; set; }

    public int? FkcourseId { get; set; }

    public int? FkstudentId { get; set; }

    public virtual Course? Fkcourse { get; set; }

    public virtual Student? Fkstudent { get; set; }
}
