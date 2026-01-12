using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCIdentity.myCompanyDBEFModels; // Imports your Context and Entities
using MVCIdentity.DTOVMs;              // Imports your DTOs

namespace MVCIdentity.Controllers
{
    public class CustomerController : Controller
    {
        // 1. Define the context variable
        private readonly MyCompanyContext _ctx;

        // 2. Constructor Injection
        public CustomerController(MyCompanyContext ctx)
        {
            _ctx = ctx;
        }

        // 3. Index Action with LINQ Query
        public async Task<ActionResult<IList<customerDTOVM>>> Index()
        {
            // LINQ Query for Step 10: 
            // Get customer with ID 10 and their addresses, mapped to DTOs.
            var customers = await _ctx.Customers
                .Where(c => c.IdCustomer == 1) // Filter for ID 10
                .Select(c => new customerDTOVM
                {
                    idCustomer = c.IdCustomer,
                    Name = c.Name,
                    // Map the related Addresses
                    Addresses = c.Adresses.Select(a => new AddressDTOVM
                    {
                        idAddress = a.IdAddress,
                        description = a.Description
                    }).ToList()
                })
                .ToListAsync();

            // NOTE: Step 10 asks to return data (JSON), but Step 11 asks for a View.
            // If you need JSON, keep the line below:
            // return customers; 

            // If you are proceeding to Step 11 (List View), change it to:
            return View(customers);

        }
    }
}