using System;
using System.Collections.Generic;

namespace WebApplication2.Entities;

public partial class Workproposal
{
    public Guid ProposalId { get; set; }

    public Guid? UserId { get; set; }

    public Guid? ClientId { get; set; }

    public string? Name { get; set; }

    public string? TalentCategory { get; set; }

    public string? SkillsRequired { get; set; }

    public int? MinYearsOfExperience { get; set; }

    public int? TotalHours { get; set; }

    public string? Description { get; set; }

    public virtual Client? Client { get; set; }

    public virtual User? User { get; set; }
}
