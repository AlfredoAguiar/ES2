using System;
using System.Collections;
using System.Collections.Generic;

namespace WebApplication2.Entities;

public partial class Talent
{
    public Guid TalentId { get; set; }

    public string? Name { get; set; }

    public string? Country { get; set; }

    public string? Email { get; set; }

    public decimal? HourlyRate { get; set; }

    public BitArray? IsPublic { get; set; }

    public virtual ICollection<Clienttalent> Clienttalents { get; set; } = new List<Clienttalent>();

    public virtual ICollection<Experience> Experiences { get; set; } = new List<Experience>();
}
