using System;
using System.Collections.Generic;

namespace abronalPortal.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? ProfilePicturePath { get; set; }

    public string GivenName { get; set; } = null!;

    public string FatherName { get; set; } = null!;

    public string GrandFatherName { get; set; } = null!;

    public DateTime? AccountCreatedAt { get; set; }

    public int? UserTypeId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? LastLogin { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual ICollection<Decision> Decisions { get; set; } = new List<Decision>();

    public virtual ICollection<TestProjectTemplate> TestProjectTemplates { get; set; } = new List<TestProjectTemplate>();

    public virtual UserType? UserType { get; set; }
}
