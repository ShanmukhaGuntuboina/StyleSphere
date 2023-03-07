using System;
using System.Collections.Generic;

namespace StyleSphere.Models;

public partial class ProductMapping
{
    public int ProductMappingId { get; set; }

    public int ProductId { get; set; }

    public int SizeId { get; set; }

    public int ColorId { get; set; }

    public bool ActiveStatus { get; set; }

    public virtual ColorMaster Color { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();

    public virtual Product Product { get; set; } = null!;

    public virtual SizesMaster Size { get; set; } = null!;
}
