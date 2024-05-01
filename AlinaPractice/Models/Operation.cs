using System;
using System.Collections.Generic;

namespace AlinaPractice.Models;

/// <summary>
/// Складские операции
/// </summary>
public partial class Operation
{
    public long IdOperations { get; set; }

    public DateOnly Date { get; set; }

    public long IdTypeOperations { get; set; }

    public long IdMedicament { get; set; }

    public long Quantity { get; set; }

    public virtual Medicament IdMedicamentNavigation { get; set; } = null!;

    public virtual TypeOperation IdTypeOperationsNavigation { get; set; } = null!;
}
