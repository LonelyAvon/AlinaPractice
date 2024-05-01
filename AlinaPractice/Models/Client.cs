using System;
using System.Collections.Generic;

namespace AlinaPractice.Models;

/// <summary>
/// Клиенты
/// </summary>
public partial class Client
{
    public long IdClient { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public long IdTypeHealthcare { get; set; }

    public string Address { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual TypeOfHealthcareInstitution IdTypeHealthcareNavigation { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
