using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potionarium.Domain.DTO
{
    public class AddPotionToInventoryDto
    {
        public Guid PotionId { get; set; }
        public string? PotionName { get; set; }
        public int Quantity { get; set; }   
    }
}
