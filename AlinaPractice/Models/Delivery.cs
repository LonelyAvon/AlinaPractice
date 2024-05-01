using System;
using System.Collections.Generic;

namespace AlinaPractice.Models;

/// <summary>
/// Доставка
/// </summary>
public partial class Delivery
{
    public long IdDelivery { get; set; }

    public DateOnly Date { get; set; }

    public string Address { get; set; } = null!;

    public long IdStatus { get; set; }

    public long IdTranspost { get; set; }

    public long IdTechnic { get; set; }

    public long IdDeliveryStaff { get; set; }

    public virtual DeliveryStaff IdDeliveryStaffNavigation { get; set; } = null!;

    public virtual Status IdStatusNavigation { get; set; } = null!;

    public virtual Technic IdTechnicNavigation { get; set; } = null!;

    public virtual Transport IdTranspostNavigation { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
