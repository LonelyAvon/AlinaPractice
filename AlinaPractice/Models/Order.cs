using System;
using System.Collections.Generic;

namespace AlinaPractice.Models;

/// <summary>
/// Заказы
/// </summary>
public partial class Order
{
    public long IdOrder { get; set; }

    public long IdApplications { get; set; }

    public long IdDelivery { get; set; }

    public long IdStatus { get; set; }

    public decimal Cost { get; set; }

    public long IdClient { get; set; }

    public virtual Application IdApplicationsNavigation { get; set; } = null!;

    public virtual Client IdClientNavigation { get; set; } = null!;

    public virtual Delivery IdDeliveryNavigation { get; set; } = null!;

    public virtual Status IdStatusNavigation { get; set; } = null!;
}
