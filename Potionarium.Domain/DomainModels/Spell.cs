using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potionarium.Domain.DomainModels
{
    public class Spell : BaseEntity
    {
        public string? Name { get; set; }
        public string? Category { get; set; }
        public string? Description { get; set; }
        public string? Effect { get; set; }
        public string? ImageURL { get; set; }
        public string? DetailsLink { get; set; }
        public bool IsFromApi { get; set; } = false;
        public virtual ICollection<SpellInSpellBook>? SpellsInBook { get; set; }
    }
}
