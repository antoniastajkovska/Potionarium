using Potionarium.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potionarium.Domain.DomainModels
{
    public class InventoryItem : BaseEntity
    {
        public Guid PotionId { get; set; }
        public Potion? Potion { get; set; }
        public Guid InventoryID { get; set; }
        public Inventory? Inventory { get; set; }
        public int Quantity { get; set; }
    }   
}
