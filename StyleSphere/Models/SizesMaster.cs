using System;
using System.Collections.Generic;

namespace StyleSphere.Models;

public partial class SizesMaster
{
    public int SizeId { get; set; }

    public string Eusize { get; set; } = null!;

    public string Ussize { get; set; } = null!;

    public bool ActiveStatus { get; set; }

    public virtual ICollection<ProductMapping> ProductMappings { get; } = new List<ProductMapping>();
}
