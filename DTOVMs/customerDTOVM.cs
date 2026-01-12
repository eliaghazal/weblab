using System;
using System.Collections.Generic; 

namespace MVCIdentity.DTOVMs
{
    public class customerDTOVM
    {
        public int idCustomer { get; set; }
        public string Name { get; set; }
        public ICollection<AddressDTOVM> Addresses { get; set; } 
    }
}