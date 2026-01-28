using Potionarium.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potionarium.Domain.DomainModels
{
    public class LearnedSpell : BaseEntity
    {
        public Guid SpellId { get; set; }
        public Spell? Spell { get; set; }

        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        public DateTime LearnedAt { get; set; } = DateTime.UtcNow;
    }
}
