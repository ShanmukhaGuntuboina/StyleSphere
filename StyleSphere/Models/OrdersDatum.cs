using System;
using System.Collections.Generic;

namespace StyleSphere.Models;

public partial class OrdersDatum
{
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public DateTime OrderDate { get; set; }

    public string ShippingAddress { get; set; } = null!;

    public string BillingAddress { get; set; } = null!;

    public string TrackingId { get; set; } = null!;

    public decimal NetAmount { get; set; }

    public bool ActiveStatus { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();
}
