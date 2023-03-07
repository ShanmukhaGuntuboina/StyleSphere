using System;
using System.Collections.Generic;

namespace StyleSphere.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string ContactNo { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public bool ActiveStatus { get; set; }

    public virtual ICollection<Favorite> Favorites { get; } = new List<Favorite>();

    public virtual ICollection<OrdersDatum> OrdersData { get; } = new List<OrdersDatum>();

    public virtual ICollection<Rating> Ratings { get; } = new List<Rating>();
}
