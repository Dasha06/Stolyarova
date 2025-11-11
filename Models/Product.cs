using System;
using System.Collections.Generic;

namespace StolyarovaDemo.Models;

public partial class Product
{
    public int PrId { get; set; }

    public string PrName { get; set; } = null!;

    public decimal PrPrice { get; set; }

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    public virtual ICollection<Specification> Specifications { get; set; } = new List<Specification>();
}
