using Potionarium.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potionarium.Domain.DTO
{
    public class SpellBookDto
    {
        public List<SpellInSpellBook>? SpellsInSpellBook { get; set; }
    }
}
