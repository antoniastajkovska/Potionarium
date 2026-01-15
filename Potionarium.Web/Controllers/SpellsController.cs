using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Potionarium.Domain.DomainModels;
using Potionarium.Domain.DTO;
using Potionarium.Repository;
using Potionarium.Service.Implementation;
using Potionarium.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Potionarium.Web.Controllers
{
    public class SpellsController : Controller
    {
        private readonly ISpellsService _spellsService;
        private readonly ISpellBookService _spellBookService;

        public SpellsController(ISpellsService spellsService, ISpellBookService spellBookService)
        {
            _spellsService = spellsService;
            _spellBookService = spellBookService;
        }

        // GET: Spells
        public async Task<IActionResult> Index()
        {
            await _spellsService.SyncSpellsFromApi();
            return View(_spellsService.GetAll());
        }

        // GET: Spells/Details/5
        public IActionResult Details(Guid id)
        {
            var spell = _spellsService.GetById(id);
            if (spell == null)
            {
                return NotFound();
            }

            return View(spell);
        }

        // GET: Spells/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Spells/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Category,Description,Effect,ImageURL,DetailsLink,Id")] Spell spell)
        {
            if (ModelState.IsValid)
            {
                _spellsService.Add(spell);
                return RedirectToAction(nameof(Index));
            }
            return View(spell);
        }

        // GET: Spells/Edit/5
        public IActionResult Edit(Guid id)
        {

            var spell = _spellsService.GetById(id);
            
            if (spell == null)
            {
                return NotFound();
            }
            return View(spell);
        }

        // POST: Spells/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Name,Category,Description,Effect,ImageURL,DetailsLink,Id")] Spell spell)
        {
            if (id != spell.Id)
            {
                return NotFound();
            }

            _spellsService.Update(spell);
            return RedirectToAction(nameof(Index));
        }

        // GET: Spells/Delete/5
        public IActionResult Delete(Guid id)
        {
            var spell = _spellsService.GetById(id);
            if (spell == null)
            {
                return NotFound();
            }

            return View(spell);
        }

        // POST: Spells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _spellsService.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }

        private bool SpellExists(Guid id)
        {
            return _spellsService.GetById(id) != null;
        }

        public IActionResult AddSpellToSpellBook(Guid id)
        {
            var spellDto = _spellBookService.GetSpellInfo(id);
            return View(spellDto);

        }
        [HttpPost]
        public IActionResult AddSpellToSpellBook(AddSpellToBookDto model)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            _spellsService.AddToSpellBook(model, Guid.Parse(userId));
            return RedirectToAction(nameof(Index));
        }
    }
}
