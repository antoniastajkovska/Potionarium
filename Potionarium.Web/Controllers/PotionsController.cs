using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Potionarium.Domain.DomainModels;
using Potionarium.Domain.DTO;
using Potionarium.Repository;
using Potionarium.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Potionarium.Web.Controllers
{
    public class PotionsController : Controller
    {
        private readonly IPotionService _potionService;
        private readonly IFetchAPIService _fetchPotionsService;
        private readonly IInventoryService _inventoryService;

        public PotionsController(IPotionService potionService, IFetchAPIService fetchPotionsService, IInventoryService inventoryService)
        {
            _potionService = potionService;
            _fetchPotionsService = fetchPotionsService;
            _inventoryService = inventoryService;
        }

        // GET: Potions
        public async Task<IActionResult> Index()
        {
            await _potionService.SyncPotionsFromApi();
            return View(_potionService.GetAll());
        }

        // GET: Potions/Details/5
        public IActionResult Details(Guid id)
        {
            var potion = _potionService.GetById(id);
            if (potion == null)
            {
                return NotFound();
            }

            return View(potion);
        }

        // GET: Potions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Potions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Difficulty,Effect,ImageURL,DetailsLink,Id")] Potion potion)
        {
            if (ModelState.IsValid)
            {
                _potionService.Add(potion);
                return RedirectToAction(nameof(Index));
            }
            return View(potion);
        }

        // GET: Potions/Edit/5
        public IActionResult Edit(Guid id)
        {
            var potion = _potionService.GetById(id);
            if (potion == null)
            {
                return NotFound();
            }
            return View(potion);
        }

        // POST: Potions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Name,Difficulty,Effect,ImageURL,DetailsLink,Id")] Potion potion)
        {
            if (id != potion.Id)
            {
                return NotFound();
            }

            _potionService.Update(potion);
            return RedirectToAction(nameof(Index));
            
        }

        // GET: Potions/Delete/5
        public IActionResult Delete(Guid id)
        {

            var potion = _potionService.GetById(id);
            if (potion == null)
            {
                return NotFound();
            }

            return View(potion);
        }

        // POST: Potions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _potionService.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }

        private bool PotionExists(Guid id)
        {
            return _potionService.GetById(id) != null;
        }

        public IActionResult AddPotionToInventory(Guid id)
        {
            var potionDto = _inventoryService.GetPotionInfo(id);
            return View(potionDto);

        }
        [HttpPost]
        public IActionResult AddPotionToInventory(AddPotionToInventoryDto model)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            _potionService.AddToInventory(model, Guid.Parse(userId));
            return RedirectToAction(nameof(Index));
        }
    }
}
