using System;
using System.Collections.Generic;

namespace AlinaPractice.Models;

/// <summary>
/// Тип складской операции
/// </summary>
public partial class TypeOperation
{
    public long IdTypeOperations { get; set; }

    public string Appellation { get; set; } = null!;

    public virtual ICollection<Operation> Operations { get; set; } = new List<Operation>();
}
