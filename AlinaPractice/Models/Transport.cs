using System;
using System.Collections.Generic;

namespace AlinaPractice.Models;

/// <summary>
/// Транспорт
/// </summary>
public partial class Transport
{
    public long IdTransport { get; set; }

    public string Appellation { get; set; } = null!;

    public string Vin { get; set; } = null!;

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();
}
