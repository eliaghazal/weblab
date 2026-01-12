using System;
using System.Collections.Generic;

namespace MVCIdentity.myCompanyDBEFModels;

public partial class Customer
{
    public int IdCustomer { get; set; }

    public string? Name { get; set; }
    public ICollection<Address> Adresses { get; set; } = new List<Address>();
}
