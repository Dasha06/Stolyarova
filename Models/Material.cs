using System;
using System.Collections.Generic;

namespace StolyarovaDemo.Models;

public partial class Material
{
    public int MatId { get; set; }

    public string MatName { get; set; } = null!;

    public decimal MatPrice { get; set; }

    public virtual ICollection<SpecMaterial> SpecMaterials { get; set; } = new List<SpecMaterial>();
}
