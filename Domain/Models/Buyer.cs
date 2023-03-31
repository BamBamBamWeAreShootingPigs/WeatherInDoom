using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Buyer
{
    public int BuyerId { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public int Passport { get; set; }

    public string HomeAddress { get; set; } = null!;

    public int PhoneNumber { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Buy> Buys { get; } = new List<Buy>();
}
