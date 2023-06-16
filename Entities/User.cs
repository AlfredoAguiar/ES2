using System;
using System.Collections.Generic;

namespace WebApplication2.Entities;

public partial class User
{
    public Guid UserId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Userskill> Userskills { get; set; } = new List<Userskill>();

    public virtual ICollection<Workproposal> Workproposals { get; set; } = new List<Workproposal>();
    

}
