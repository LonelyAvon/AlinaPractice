using System;
using System.Collections.Generic;

namespace AlinaPractice.Models;

/// <summary>
/// Способы применения
/// </summary>
public partial class MethodsOfApplication
{
    public long IdMethodsOfApplication { get; set; }

    public string Appellation { get; set; } = null!;

    public virtual ICollection<Medicament> Medicaments { get; set; } = new List<Medicament>();
}
