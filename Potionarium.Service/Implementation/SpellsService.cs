using Microsoft.Extensions.Options;
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
    public class SpellsService : ISpellsService
    {
        private readonly IRepository<Spell> _spellRepository;
        private readonly IFetchAPIService _fetchAPIService;
        private readonly ISpellBookService _spellBookService;
        private readonly IRepository<SpellInSpellBook> _spellInSpellBookRepository;

        public SpellsService(IRepository<Spell> spellRepository, IFetchAPIService fetchAPIService, ISpellBookService spellBookService, IRepository<SpellInSpellBook> spellInSpellBookRepository)
        {
            _spellRepository = spellRepository;
            _fetchAPIService = fetchAPIService;
            _spellBookService = spellBookService;
            _spellInSpellBookRepository = spellInSpellBookRepository;
        }

        public Spell Add(Spell spell)
        {
            spell.Id = Guid.NewGuid();
            return _spellRepository.Insert(spell);
        }

        public void AddToSpellBook(AddSpellToBookDto modelDTO, Guid userId)
        {
            var spellBook = _spellBookService.GetByUserId(userId);
            var spell = _spellRepository.Get(selector: x => x,
                predicate: x => x.Id == modelDTO.SpellId);

            var existing = _spellInSpellBookRepository.Get(selector: x => x,
                predicate: x => x.SpellId == modelDTO.SpellId && x.SpellBookId == spellBook.Id);

            if (existing == null)
            {
                SpellInSpellBook newSpell = new SpellInSpellBook
                {
                    Id = Guid.NewGuid(),
                    Spell = spell,
                    SpellId = modelDTO.SpellId,
                    SpellBook = spellBook,
                    SpellBookId = spellBook.Id,
                };

                _spellInSpellBookRepository.Insert(newSpell);
            }
        }

        public Spell DeleteById(Guid Id)
        {
            var spell = _spellRepository.Get(selector: x => x,
                predicate: x => x.Id == Id);
            return _spellRepository.Delete(spell);
        }

        public List<Spell> GetAll()
        {
            return _spellRepository.GetAll(selector: x => x).ToList();
        }

        public Spell? GetById(Guid Id)
        {
            return _spellRepository.Get(selector: x => x,
                                            predicate: x => x.Id == Id);
        }

        public async Task SyncSpellsFromApi()
        {
            var apiSpells = await _fetchAPIService.GetAllSpellsAsync();

            foreach(var apiSpell in apiSpells)
            {
                var exists = GetAll()
                    .Any(s => s.Id == apiSpell.Id);

                if (!exists)
                {
                    var newSpell = new Spell
                    {
                        Id = apiSpell.Id,
                        Name = apiSpell.name,
                        Category = apiSpell.category,
                        Effect = apiSpell.effect,
                        ImageURL = apiSpell.image,
                        DetailsLink = apiSpell.wiki,
                        IsFromApi = true
                    };
                    _spellRepository.Insert(newSpell);
                }
            }
        }

        public Spell Update(Spell spell)
        {
            return _spellRepository.Update(spell);
        }
    }
}
