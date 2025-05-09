using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;


namespace abronalPortal.Models;

public partial class Application
{
    public int ApplicationId { get; set; }

    public int? UserId { get; set; }

    public int? CurrentStatusId { get; set; }

    public string? Designation { get; set; }

    public string? Bio { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public bool? WillingToRelocate { get; set; }

    public string? University { get; set; }

    public string? CurrentYear { get; set; }

    public decimal? Cgpa { get; set; }

    public string? Major { get; set; }

    public string? Skills { get; set; }

    public string? ResumePath { get; set; }

    public string? GitHubProfileLink { get; set; }

    public string? LinkedInProfileLink { get; set; }

    public string? LeetCodeProfileLink { get; set; }

    public string? PortfolioSiteLink { get; set; }

    [NotMapped]
    public List<PastProject> PastProjects
    {
        get => string.IsNullOrEmpty(PastProjectsJson)
            ? new List<PastProject>()
            : JsonSerializer.Deserialize<List<PastProject>>(PastProjectsJson) ?? new List<PastProject>();
        set => PastProjectsJson = JsonSerializer.Serialize(value);
    }

    public string? PastProjectsJson { get; set; }

    public string? CoverLetter { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? LastUpdated { get; set; }

    public virtual ApplicantTestProject? ApplicantTestProject { get; set; }

    public virtual ApplicationStatus? CurrentStatus { get; set; }

    public virtual ICollection<Decision> Decisions { get; set; } = new List<Decision>();

    public virtual User? User { get; set; }
}
