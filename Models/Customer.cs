using System;
using System.Collections.Generic;

namespace StolyarovaDemo.Models;

public partial class Customer
{
    public int CustomId { get; set; }

    public string CustomName { get; set; } = null!;

    public long? CustomInn { get; set; }

    public string CustomAddress { get; set; } = null!;

    public string CustomPhone { get; set; } = null!;

    public bool CustomSalesman { get; set; }

    public bool CustomBuyer { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
