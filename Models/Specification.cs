using System;
using System.Collections.Generic;

namespace StolyarovaDemo.Models;

public partial class Specification
{
    public int SpecId { get; set; }

    public int? PrId { get; set; }

    public int SpecCount { get; set; }

    public int? UnitId { get; set; }

    public string CustomIdProducer { get; set; } = null!;

    public virtual Product? Pr { get; set; }

    public virtual ICollection<SpecMaterial> SpecMaterials { get; set; } = new List<SpecMaterial>();

    public virtual Unit? Unit { get; set; }
}
