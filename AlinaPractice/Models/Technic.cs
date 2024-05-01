using System;
using System.Collections.Generic;

namespace AlinaPractice.Models;

/// <summary>
/// Техника
/// </summary>
public partial class Technic
{
    public long IdTechnic { get; set; }

    public string Appellation { get; set; } = null!;

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();
}
