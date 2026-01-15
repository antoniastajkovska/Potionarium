using Potionarium.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potionarium.Domain.DomainModels
{
    public class SpellBook : BaseEntity
    {
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public virtual ICollection<SpellInSpellBook>? SpellsInSpellBook { get; set; }
    }
}
