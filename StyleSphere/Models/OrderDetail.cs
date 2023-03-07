using System;
using System.Collections.Generic;

namespace StyleSphere.Models;

public partial class OrderDetail
{
    public int OrderDetailsId { get; set; }

    public string Quantity { get; set; } = null!;

    public decimal Price { get; set; }

    public int ProductMappingId { get; set; }

    public int OrderId { get; set; }

    public string Total { get; set; } = null!;

    public bool ActiveStatus { get; set; }

    public virtual OrdersDatum Order { get; set; } = null!;

    public virtual ProductMapping ProductMapping { get; set; } = null!;
}
