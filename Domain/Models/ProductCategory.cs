using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class ProductCategory
{
    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int? ParentCategotyId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<ProductCategory> InverseParentCategoty { get; } = new List<ProductCategory>();

    public virtual ProductCategory? ParentCategoty { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
