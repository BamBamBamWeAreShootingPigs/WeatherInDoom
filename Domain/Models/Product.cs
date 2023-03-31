using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    public int QuanityInStock { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ProductCategory Category { get; set; } = null!;

    public virtual ICollection<PurchaseContent> PurchaseContents { get; } = new List<PurchaseContent>();
}
