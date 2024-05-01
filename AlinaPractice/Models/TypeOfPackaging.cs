using System;
using System.Collections.Generic;

namespace AlinaPractice.Models;

/// <summary>
/// Вид упаковки
/// </summary>
public partial class TypeOfPackaging
{
    public long IdTypeOfPackaging { get; set; }

    public string Appellation { get; set; } = null!;

    public virtual ICollection<Medicament> Medicaments { get; set; } = new List<Medicament>();
}
