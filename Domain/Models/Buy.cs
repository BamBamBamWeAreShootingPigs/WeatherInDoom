using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Buy
{
    public int PurchaseId { get; set; }

    public DateTime PurchaseDate { get; set; }

    public int BuyerId { get; set; }

    public int SellerId { get; set; }

    public bool IsDeleted { get; set; }

    public string Status { get; set; } = null!;

    public string DeliveryType { get; set; } = null!;

    public virtual Buyer Buyer { get; set; } = null!;

    public virtual ICollection<PurchaseContent> PurchaseContents { get; } = new List<PurchaseContent>();

    public virtual Seller Seller { get; set; } = null!;
}
