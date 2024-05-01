using System;
using System.Collections.Generic;

namespace AlinaPractice.Models;

/// <summary>
/// Вид учреждения здравоохранения
/// </summary>
public partial class TypeOfHealthcareInstitution
{
    public long IdTypeHealthcare { get; set; }

    public string Appellation { get; set; } = null!;

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
