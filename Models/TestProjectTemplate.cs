using System;
using System.Collections.Generic;

namespace abronalPortal.Models;

public partial class TestProjectTemplate
{
    public int TemplateId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? Features { get; set; }

    public string? TechnologiesToUse { get; set; }

    public string? OptionalLibraries { get; set; }

    public int? CreatedByAdminId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<ApplicantTestProject> ApplicantTestProjects { get; set; } = new List<ApplicantTestProject>();

    public virtual User? CreatedByAdmin { get; set; }
}
