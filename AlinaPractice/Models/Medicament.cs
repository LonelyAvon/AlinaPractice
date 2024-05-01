using System;
using System.Collections.Generic;

namespace AlinaPractice.Models;

/// <summary>
/// Препараты
/// </summary>
public partial class Medicament
{
    public long IdMedicament { get; set; }

    public long IdInn { get; set; }

    public string TradeName { get; set; } = null!;

    public long IdManufacturer { get; set; }

    public string Dosage { get; set; } = null!;

    public long IdReleaseForm { get; set; }

    public long IdTypeOfPackaging { get; set; }

    public string Quantity { get; set; } = null!;

    public long IdMethodsOfApplication { get; set; }

    public long IdBatchNumber { get; set; }

    public long IdOkpd2 { get; set; }

    public decimal PurchasePrice { get; set; }

    public decimal Cost { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual ICollection<Availability> Availabilities { get; set; } = new List<Availability>();

    public virtual BatchNumber IdBatchNumberNavigation { get; set; } = null!;

    public virtual Inn IdInnNavigation { get; set; } = null!;

    public virtual Manufacturer IdManufacturerNavigation { get; set; } = null!;

    public virtual MethodsOfApplication IdMethodsOfApplicationNavigation { get; set; } = null!;

    public virtual Okpd IdOkpd2Navigation { get; set; } = null!;

    public virtual ReleaseForm IdReleaseFormNavigation { get; set; } = null!;

    public virtual TypeOfPackaging IdTypeOfPackagingNavigation { get; set; } = null!;

    public virtual ICollection<Operation> Operations { get; set; } = new List<Operation>();
}
