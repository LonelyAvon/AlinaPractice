using System;
using System.Collections.Generic;

namespace AlinaPractice.Models;

/// <summary>
/// Заявки
/// </summary>
public partial class Application
{
    public long IdApplications { get; set; }

    public long IdMedicament { get; set; }

    public long Quantity { get; set; }

    public decimal Cost { get; set; }

    public virtual Medicament IdMedicamentNavigation { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
