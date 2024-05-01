using System;
using System.Collections.Generic;

namespace AlinaPractice.Models;

/// <summary>
/// Форма выпуска
/// </summary>
public partial class ReleaseForm
{
    public long IdReleaseForm { get; set; }

    public string Appellation { get; set; } = null!;

    public virtual ICollection<Medicament> Medicaments { get; set; } = new List<Medicament>();
}
