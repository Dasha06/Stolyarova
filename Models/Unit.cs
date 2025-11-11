using System;
using System.Collections.Generic;

namespace StolyarovaDemo.Models;

public partial class Unit
{
    public int UnitId { get; set; }

    public string UnitName { get; set; } = null!;

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    public virtual ICollection<SpecMaterial> SpecMaterials { get; set; } = new List<SpecMaterial>();

    public virtual ICollection<Specification> Specifications { get; set; } = new List<Specification>();
}
