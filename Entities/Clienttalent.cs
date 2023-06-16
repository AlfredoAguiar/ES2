using System;
using System.Collections.Generic;

namespace WebApplication2.Entities;

public partial class Clienttalent
{
    public Guid ClientTalentId { get; set; }

    public Guid? ClientId { get; set; }

    public Guid? TalentId { get; set; }

    public virtual Client? Client { get; set; }

    public virtual Talent? Talent { get; set; }
}
