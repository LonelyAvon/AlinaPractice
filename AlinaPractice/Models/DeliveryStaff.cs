using System;
using System.Collections.Generic;

namespace AlinaPractice.Models;

public partial class DeliveryStaff
{
    public long IdDeliveryStaff { get; set; }

    public long Driver { get; set; }

    public long Logistics { get; set; }

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();

    public virtual Employee DriverNavigation { get; set; } = null!;

    public virtual Employee LogisticsNavigation { get; set; } = null!;
}
