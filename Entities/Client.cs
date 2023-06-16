using System;
using System.Collections.Generic;

namespace WebApplication2.Entities;

public partial class Client
{
    public Guid ClientId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Clienttalent> Clienttalents { get; set; } = new List<Clienttalent>();

    public virtual ICollection<Workproposal> Workproposals { get; set; } = new List<Workproposal>();
}
