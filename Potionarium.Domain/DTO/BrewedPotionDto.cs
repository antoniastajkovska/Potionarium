using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potionarium.Domain.DTO
{
    public class BrewedPotionDto
    {
        public Guid PotionId { get; set; }
        public string? PotionName { get; set; }
        public string? Effect { get; set; }
        public string? ImageURL { get; set; }
        public DateTime BrewedOn { get; set; }
    }
}
