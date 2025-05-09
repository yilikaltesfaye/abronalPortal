using System;
using System.Collections.Generic;

namespace abronalPortal.Models;

public partial class ApplicationStatus
{
    public int StatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<ApplicantTestProject> ApplicantTestProjects { get; set; } = new List<ApplicantTestProject>();

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual ICollection<Decision> Decisions { get; set; } = new List<Decision>();
}
