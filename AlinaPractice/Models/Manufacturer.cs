using System;
using System.Collections.Generic;

namespace AlinaPractice.Models;

/// <summary>
/// Производитель
/// </summary>
public partial class Manufacturer
{
    public long IdManufacturer { get; set; }

    public string Address { get; set; } = null!;

    public string MSurname { get; set; } = null!;

    public string MName { get; set; } = null!;

    public string MPatronymic { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Appellation { get; set; } = null!;

    public virtual ICollection<Medicament> Medicaments { get; set; } = new List<Medicament>();
}
