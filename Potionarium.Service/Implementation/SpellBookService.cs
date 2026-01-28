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
        private readonly IRepository<LearnedSpell> _learnedSpellRepo;

        public SpellBookService(IRepository<SpellInSpellBook> spellInSpellBookRepo, IRepository<Spell> spellRepository, IRepository<SpellBook> spellBookReposiory, IRepository<LearnedSpell> learnedSpellRepo)
        {
            _spellInSpellBookRepo = spellInSpellBookRepo;
            _spellRepository = spellRepository;
            _spellBookReposiory = spellBookReposiory;
            _learnedSpellRepo = learnedSpellRepo;
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

        public bool LearnAllSpells(Guid userId)
        {
            var spellBook = _spellBookReposiory.Get(
                selector: x => x,
                predicate: x => x.UserId == userId.ToString(),
                include: x => x.Include(s => s.SpellsInSpellBook).ThenInclude(si => si.Spell)
            );

            if (spellBook?.SpellsInSpellBook == null || !spellBook.SpellsInSpellBook.Any())
                return false;

            foreach (var spellInBook in spellBook.SpellsInSpellBook)
            {
                var learnedSpell = new LearnedSpell
                {
                    Id = Guid.NewGuid(),
                    SpellId = spellInBook.SpellId,
                    UserId = userId.ToString(),
                    LearnedAt = DateTime.UtcNow
                };

                _learnedSpellRepo.Insert(learnedSpell); 
            }

            foreach (var spellInBook in spellBook.SpellsInSpellBook.ToList())
            {
                _spellInSpellBookRepo.Delete(spellInBook);
            }

            return true;
        }

    }
}
