using System;
using System.Collections.Generic;

namespace StolyarovaDemo.Models;

public partial class OrderProduct
{
    public int OrdId { get; set; }

    public int PrId { get; set; }

    public int OrdprdCount { get; set; }

    public decimal? OrdprdSummPrice { get; set; }

    public int? UnitId { get; set; }

    public virtual Order Ord { get; set; } = null!;

    public virtual Product Pr { get; set; } = null!;

    public virtual Unit? Unit { get; set; }
}
