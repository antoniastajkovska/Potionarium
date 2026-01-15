using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potionarium.Domain.DTO
{
    public class SpellDataWrapper
    {
        public Guid Id { get; set; }
        public string? type { get; set; }
        public SpellDto? attributes { get; set; }
    }
}
