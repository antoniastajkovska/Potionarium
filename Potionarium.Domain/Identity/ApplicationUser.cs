using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Potionarium.Domain.DomainModels;

namespace Potionarium.Domain.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? House { get; set; }
        public Inventory? Inventory { get; set; }
        public SpellBook? SpellBook { get; set; }
    }
}
