using System;
using System.Collections.Generic;

namespace AlinaPractice.Models;

/// <summary>
/// Должности
/// </summary>
public partial class Post
{
    public long IdPost { get; set; }

    public long? IdDepartment { get; set; }

    public string Appellation { get; set; } = null!;

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual Department? IdDepartmentNavigation { get; set; }
}
