using Microsoft.AspNetCore.Mvc;
using Potionarium.Service.Interface;
using System;
using System.Security.Claims;

namespace Potionarium.Web.Controllers
{
    public class BrewedPotionsController : Controller
    {
        private readonly IInventoryService _inventoryService;

        public BrewedPotionsController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var brewedPotions = _inventoryService.GetBrewedPotionsByUser(Guid.Parse(userId));
            return View(brewedPotions);
        }
    }
}
