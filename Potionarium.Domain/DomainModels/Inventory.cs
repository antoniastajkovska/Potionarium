using Potionarium.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potionarium.Domain.DomainModels
{
    public class Inventory : BaseEntity
    {
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public virtual ICollection<InventoryItem>? PotionsInInventory { get; set; }
    }
}
