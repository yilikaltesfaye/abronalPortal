using System;
using System.Collections.Generic;

namespace abronalPortal.Models;

public partial class Decision
{
    public int DecisionId { get; set; }

    public int? ApplicationId { get; set; }

    public int? AdminId { get; set; }

    public DateTime? DecisionDate { get; set; }

    public int? NewStatusId { get; set; }

    public string Description { get; set; } = null!;

    public bool? IsTestProjectAssigned { get; set; }

    public string? TestProjectRequirements { get; set; }

    public virtual User? Admin { get; set; }

    public virtual Application? Application { get; set; }

    public virtual ApplicationStatus? NewStatus { get; set; }
}
