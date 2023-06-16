using System;
using System.Collections.Generic;

namespace WebApplication2.Entities;

public partial class Userskill
{
    public Guid UserSkillId { get; set; }

    public Guid? UserId { get; set; }

    public Guid? SkillId { get; set; }

    public int? YearsOfExperience { get; set; }

    public virtual Skill? Skill { get; set; }

    public virtual User? User { get; set; }
}
