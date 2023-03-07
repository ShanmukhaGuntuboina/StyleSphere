using System;
using System.Collections.Generic;

namespace StyleSphere.Models;

public partial class SubCategory
{
    public int SubCategoryId { get; set; }

    public int CategoryId { get; set; }

    public string SubCategoryName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool ActiveStatus { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();

    public virtual Category SubCategoryNavigation { get; set; } = null!;
}
