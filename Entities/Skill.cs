using System;
using System.Collections.Generic;

namespace WebApplication2.Entities;

public partial class Skill
{
    public Guid SkillId { get; set; }

    public string? Name { get; set; }

    public string? ProfessionArea { get; set; }

    public virtual ICollection<Userskill> Userskills { get; set; } = new List<Userskill>();
}
