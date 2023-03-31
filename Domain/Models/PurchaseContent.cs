using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class PurchaseContent
{
    public int ProductId { get; set; }

    public int PurchaseId { get; set; }

    public int Amount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Buy Purchase { get; set; } = null!;
}
