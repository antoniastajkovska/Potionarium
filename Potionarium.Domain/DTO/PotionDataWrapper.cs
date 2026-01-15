using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potionarium.Domain.DTO
{
    public class PotionDataWrapper
    {
        public Guid id { get; set; }
        public string? type { get; set; }
        public PotionDto? attributes { get; set; }
    }
}
