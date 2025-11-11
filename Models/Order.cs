using System;
using System.Collections.Generic;

namespace StolyarovaDemo.Models;

public partial class Order
{
    public int OrdId { get; set; }

    public string CustomIdSalesman { get; set; } = null!;

    public int? CustomIdBuyer { get; set; }

    public decimal OrdFullprice { get; set; }

    public virtual Customer? CustomIdBuyerNavigation { get; set; }

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
}
