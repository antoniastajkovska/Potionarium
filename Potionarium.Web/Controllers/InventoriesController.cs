using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Potionarium.Domain.DomainModels;
using Potionarium.Repository;
using Potionarium.Service.Interface;

namespace Potionarium.Web.Controllers
{
    public class InventoriesController : Controller
    {
        private readonly IInventoryService _inventoryService;

        public InventoriesController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }


        // GET: Inventories
        public IActionResult Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var inventory = _inventoryService.GetByUserIdIncudingPotions(Guid.Parse(userId));
            return View(inventory);
        }

        public IActionResult RemoveFromInventory(Guid id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            _inventoryService.RemoveFromInventory(id, userId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult BrewPotions()
        {
            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            _inventoryService.BrewPotions(userId);

            return RedirectToAction("Index");
        }


    }
}
