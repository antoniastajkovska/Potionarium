using Potionarium.Domain.DomainModels;
using Potionarium.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potionarium.Service.Interface
{
    public interface ISpellBookService
    {
        SpellBook GetByUserId(Guid id);
        SpellBookDto GetByUserIdIncudingSpells(Guid id);
        AddSpellToBookDto GetSpellInfo(Guid id);
        Boolean RemoveFromSpellBook(Guid id, string userId);
    }
}