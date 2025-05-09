using System;
using System.Collections.Generic;

namespace abronalPortal.Models;

public partial class ApplicantTestProject
{
    public int ApplicantTestProjectId { get; set; }

    public int? ApplicationId { get; set; }

    public int? TemplateId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? CustomFeatures { get; set; }

    public string? OptionalLibraries { get; set; }

    public DateTime? AssignedDate { get; set; }

    public DateTime? Deadline { get; set; }

    public string? GitHubRepoUrl { get; set; }

    public string? LiveSiteUrl { get; set; }

    public DateTime? SubmittedDate { get; set; }

    public int? CurrentStatusId { get; set; }

    public virtual Application? Application { get; set; }

    public virtual ApplicationStatus? CurrentStatus { get; set; }

    public virtual TestProjectTemplate? Template { get; set; }
}
