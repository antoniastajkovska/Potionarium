using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potionarium.Domain.DomainModels
{
    public class SpellInSpellBook : BaseEntity
    {
        public Guid SpellId { get; set; }
        public Spell? Spell { get; set; }
        public Guid SpellBookId { get; set; }
        public SpellBook? SpellBook { get; set; }
    }
}
