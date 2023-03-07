using System;
using System.Collections.Generic;

namespace StyleSphere.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public int CategoryId { get; set; }

    public int SubCategoryId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }

    public DateTime MfgDate { get; set; }

    public string ThumbnailImage { get; set; } = null!;

    public string Image1 { get; set; } = null!;

    public string? Image2 { get; set; }

    public string? Image3 { get; set; }

    public string Description { get; set; } = null!;

    public bool ActiveStatus { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Favorite> Favorites { get; } = new List<Favorite>();

    public virtual ICollection<ProductMapping> ProductMappings { get; } = new List<ProductMapping>();

    public virtual ICollection<Rating> Ratings { get; } = new List<Rating>();

    public virtual SubCategory SubCategory { get; set; } = null!;
}
