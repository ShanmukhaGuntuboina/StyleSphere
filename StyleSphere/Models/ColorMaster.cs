using System;
using System.Collections.Generic;

namespace StyleSphere.Models;

public partial class ColorMaster
{
    public int ColorId { get; set; }

    public string Color { get; set; } = null!;

    public bool ActiveStatus { get; set; }

    public virtual ICollection<ProductMapping> ProductMappings { get; } = new List<ProductMapping>();
}
