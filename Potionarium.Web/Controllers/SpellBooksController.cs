using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Potionarium.Domain.DomainModels;
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
    public class SpellBooksController : Controller
    {
        private readonly ISpellBookService _spellBookService;

        public SpellBooksController(ISpellBookService spellBookService)
        {
            _spellBookService = spellBookService;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var spellBook = _spellBookService.GetByUserIdIncudingSpells(Guid.Parse(userId));
            return View(spellBook);
        }

        public IActionResult RemoveFromSpellBook(Guid id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            _spellBookService.RemoveFromSpellBook(id, userId);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult LearnAll()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            _spellBookService.LearnAllSpells(Guid.Parse(userId)); 

            TempData["LearnedAll"] = true;

            return RedirectToAction("Index");
        }


    }
}
