using System;
using System.Collections.Generic;

namespace AlinaPractice.Models;

public partial class Account
{
    public long IdEmployee { get; set; }

    public long? IdPost { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public long IdUser { get; set; }

    public virtual Employee IdEmployeeNavigation { get; set; } = null!;

    public virtual Post? IdPostNavigation { get; set; }
}
