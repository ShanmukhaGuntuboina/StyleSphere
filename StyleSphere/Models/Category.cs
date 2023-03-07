using System;
using System.Collections.Generic;

namespace StyleSphere.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool ActiveStatus { get; set; }

    public bool ShowOnTop { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();

    public virtual SubCategory? SubCategory { get; set; }
}
