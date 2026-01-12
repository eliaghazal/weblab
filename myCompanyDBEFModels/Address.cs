using System;
using System.Collections.Generic;

namespace MVCIdentity.myCompanyDBEFModels;

public partial class Address
{
    public int IdAddress { get; set; }

    public string? Description { get; set; }

    public int? IdCustomer { get; set; }
    public virtual Customer? Customer { get; set; }
}
