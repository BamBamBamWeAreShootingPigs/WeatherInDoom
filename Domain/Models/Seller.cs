using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Seller
{
    public int SellerId { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string JobTitle { get; set; } = null!;

    public string HomeAddress { get; set; } = null!;

    public int PhoneNumber { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Buy> Buys { get; } = new List<Buy>();
}
