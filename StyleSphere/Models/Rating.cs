using System;
using System.Collections.Generic;

namespace StyleSphere.Models;

public partial class Rating
{
    public int RatingId { get; set; }

    public int ProductId { get; set; }

    public int CustomerId { get; set; }

    public int Rating1 { get; set; }

    public bool ActiveStatus { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
