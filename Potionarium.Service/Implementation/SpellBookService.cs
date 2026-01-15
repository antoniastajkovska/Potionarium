using Microsoft.EntityFrameworkCore;
using Potionarium.Domain.DomainModels;
using Potionarium.Domain.DTO;
using Potionarium.Repository;
using Potionarium.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potionarium.Service.Implementation
{
    public class SpellBookService : ISpellBookService
    {
        private readonly IRepository<SpellBook> _spellBookReposiory;
        private readonly IRepository<Spell> _spellRepository;
        private readonly IRepository<SpellInSpellBook> _spellInSpellBookRepo;

        public SpellBookService(IRepository<SpellInSpellBook> spellInSpellBookRepo, IRepository<Spell> spellRepository, IRepository<SpellBook> spellBookReposiory)
        {
            _spellInSpellBookRepo = spellInSpellBookRepo;
            _spellRepository = spellRepository;
            _spellBookReposiory = spellBookReposiory;
        }

        public SpellBook GetByUserId(Guid id)
        {
            return _spellBookReposiory.Get(selector: x => x,
                                               predicate: x => x.UserId == id.ToString());
        }

        public SpellBookDto GetByUserIdIncudingSpells(Guid id)
        {
            var spellBook = _spellBookReposiory.Get(selector: x => x,
                predicate: x => x.UserId == id.ToString(),
                include: x => x.Include(y => y.SpellsInSpellBook).ThenInclude(z => z.Spell));

            var allSpells = spellBook.SpellsInSpellBook.ToList();

            SpellBookDto model = new SpellBookDto
            {
                SpellsInSpellBook = allSpells
            };
            return model;
        }

        public AddSpellToBookDto GetSpellInfo(Guid id)
        {
            var spell = _spellRepository.Get(selector: x => x,
                predicate: x => x.Id == id);
            var dto = new AddSpellToBookDto
            {
                SpellId = id,
                SpellName = spell.Name
            };

            return dto;
        }

        public bool RemoveFromSpellBook(Guid id, string userId)
        {
            var spellBook = _spellBookReposiory.Get(selector: x => x,
                                               predicate: x => x.UserId == userId);

            var spellToRemove = _spellInSpellBookRepo.Get(selector: x => x,
                predicate: x => x.SpellId == id && x.SpellBook == spellBook);

            _spellInSpellBookRepo.Delete(spellToRemove);
            return true;
        }
    }
}
