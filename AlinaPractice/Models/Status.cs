using System;
using System.Collections.Generic;

namespace AlinaPractice.Models;

/// <summary>
/// Статус
/// 
/// </summary>
public partial class Status
{
    public long IdStatus { get; set; }

    public string Appellation { get; set; } = null!;

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
