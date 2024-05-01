using System;
using System.Collections.Generic;

namespace AlinaPractice.Models;

/// <summary>
/// Наличие
/// </summary>
public partial class Availability
{
    public long IdAvailability { get; set; }

    public long IdMedicament { get; set; }

    public long IdBatchNumber { get; set; }

    public long Quantity { get; set; }

    public virtual BatchNumber IdBatchNumberNavigation { get; set; } = null!;

    public virtual Medicament IdMedicamentNavigation { get; set; } = null!;
}
