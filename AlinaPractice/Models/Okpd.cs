using System;
using System.Collections.Generic;

namespace AlinaPractice.Models;

/// <summary>
/// Код ОКПД 2
/// </summary>
public partial class Okpd
{
    public long IdOkpd2 { get; set; }

    public string Appellation { get; set; } = null!;

    public virtual ICollection<Medicament> Medicaments { get; set; } = new List<Medicament>();
}
