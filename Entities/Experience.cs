using System;
using System.Collections.Generic;

namespace WebApplication2.Entities;

public partial class Experience
{
    public Guid ExperienceId { get; set; }

    public Guid? TalentId { get; set; }

    public string? Title { get; set; }

    public string? CompanyName { get; set; }

    public int? StartYear { get; set; }

    public int? EndYear { get; set; }

    public virtual Talent? Talent { get; set; }
}
