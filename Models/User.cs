using System;
using System.Collections.Generic;

namespace StolyarovaDemo.Models;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string UserLogin { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public int? UroleId { get; set; }

    public virtual Role? Urole { get; set; }
}
