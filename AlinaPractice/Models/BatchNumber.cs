using System;
using System.Collections.Generic;

namespace AlinaPractice.Models;

/// <summary>
/// Номер партии
/// </summary>
public partial class BatchNumber
{
    public long IdBatchNumber { get; set; }

    public long Volume { get; set; }

    public DateOnly DProduction { get; set; }

    public DateOnly DReceipt { get; set; }

    public DateOnly DExpiration { get; set; }

    public virtual ICollection<Availability> Availabilities { get; set; } = new List<Availability>();

    public virtual ICollection<Medicament> Medicaments { get; set; } = new List<Medicament>();
}
