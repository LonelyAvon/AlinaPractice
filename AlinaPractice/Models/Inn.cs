using System;
using System.Collections.Generic;

namespace AlinaPractice.Models;

/// <summary>
/// INN - international nonproprietary name
/// МНН - международное непатентованное наименование
/// </summary>
public partial class Inn
{
    public long IdInn { get; set; }

    public string Appellation { get; set; } = null!;

    public virtual ICollection<Medicament> Medicaments { get; set; } = new List<Medicament>();
}
