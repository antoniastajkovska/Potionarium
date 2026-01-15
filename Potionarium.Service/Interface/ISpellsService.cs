using Potionarium.Domain.DomainModels;
using Potionarium.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potionarium.Service.Interface
{
    public interface ISpellsService
    {
        List<Spell> GetAll();
        Spell? GetById(Guid Id);
        Spell Update(Spell spell);
        Spell DeleteById(Guid Id);
        Spell Add(Spell spell);
        Task SyncSpellsFromApi();
        void AddToSpellBook(AddSpellToBookDto modelDTO, Guid userId);

    }
}
