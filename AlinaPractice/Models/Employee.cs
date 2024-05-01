using System;
using System.Collections.Generic;

namespace AlinaPractice.Models;

/// <summary>
/// Сотрудники
/// </summary>
public partial class Employee
{
    public long IdEmployee { get; set; }

    public long IdPost { get; set; }

    public DateOnly? DEmployment { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public DateOnly? Birthday { get; set; }

    public string Passport { get; set; } = null!;

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual ICollection<DeliveryStaff> DeliveryStaffDriverNavigations { get; set; } = new List<DeliveryStaff>();

    public virtual ICollection<DeliveryStaff> DeliveryStaffLogisticsNavigations { get; set; } = new List<DeliveryStaff>();

    public virtual Post IdPostNavigation { get; set; } = null!;
}
