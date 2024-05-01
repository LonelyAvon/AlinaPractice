using System;
using System.Collections.Generic;

namespace AlinaPractice.Models;

/// <summary>
/// Отделы
/// </summary>
public partial class Department
{
    public long IdDepartment { get; set; }

    public string Appellation { get; set; } = null!;

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
