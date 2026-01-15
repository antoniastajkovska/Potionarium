using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potionarium.Domain.DTO
{
    public class AddSpellToBookDto
    {
        public Guid SpellId { get; set; }
        public string? SpellName { get; set; }
    }
}
