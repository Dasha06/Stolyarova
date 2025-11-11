using System;
using System.Collections.Generic;

namespace StolyarovaDemo.Models;

public partial class SpecMaterial
{
    public int SpecId { get; set; }

    public int MatId { get; set; }

    public int? SpmatUnits { get; set; }

    public decimal? SpmatCount { get; set; }

    public virtual Material Mat { get; set; } = null!;

    public virtual Specification Spec { get; set; } = null!;

    public virtual Unit? SpmatUnitsNavigation { get; set; }
}
