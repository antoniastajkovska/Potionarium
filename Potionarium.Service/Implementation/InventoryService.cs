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
    public class InventoryService : IInventoryService
    {
        private readonly IRepository<Inventory> _inventoryRepository;
        private readonly IRepository<Potion> _potionRepository;
        private readonly IRepository<InventoryItem> _inventoryItemRepository;
        private readonly IRepository<BrewedPotion> _brewedPotionRepository;


        public InventoryService(IRepository<Inventory> inventoryRepository, IRepository<Potion> potionRepository, IRepository<InventoryItem> inventoryItemRepository, IRepository<BrewedPotion> brewedPotionRepository)
        {
            _inventoryRepository = inventoryRepository;
            _potionRepository = potionRepository;
            _inventoryItemRepository = inventoryItemRepository;
            _brewedPotionRepository = brewedPotionRepository;
        }

        public Inventory GetByUserId(Guid id)
        {
            return _inventoryRepository.Get(selector: x => x,
                                               predicate: x => x.UserId == id.ToString());
        }

        public InventoryDto GetByUserIdIncudingPotions(Guid id)
        {
            var inventory = _inventoryRepository.Get(selector: x => x,
                predicate: x => x.UserId == id.ToString(),
                include: x => x.Include(y => y.PotionsInInventory).ThenInclude(z => z.Potion));

            var allPotions = inventory.PotionsInInventory.ToList();

            InventoryDto model = new InventoryDto
            {
                InventoryItems = allPotions
            };
            return model;
        }

        public AddPotionToInventoryDto GetPotionInfo(Guid id)
        {
            var potion = _potionRepository.Get(selector: x => x,
                predicate: x => x.Id == id);
            var dto = new AddPotionToInventoryDto
            {
                PotionId = id,
                PotionName = potion?.Name,
                Quantity = 1
            };

            return dto;
        }


        public bool RemoveFromInventory(Guid id, string userId)
        {
            var inventory = _inventoryRepository.Get(selector: x => x,
                                               predicate: x => x.UserId == userId);

            var potionToRemove = _inventoryItemRepository.Get(selector: x => x,
                predicate: x => x.PotionId == id && x.Inventory == inventory);

            _inventoryItemRepository.Delete(potionToRemove);
            return true;
        }


        public void BrewPotions(Guid userId)
        {
            var inventory = _inventoryRepository.Get(
                selector: x => x,
                predicate: x => x.UserId == userId.ToString(),
                include: x => x
                    .Include(i => i.PotionsInInventory)
                    .ThenInclude(pi => pi.Potion)
            );

            if (inventory == null || !inventory.PotionsInInventory.Any())
                return;

            foreach (var item in inventory.PotionsInInventory)
            {
                var brewedPotion = new BrewedPotion
                {
                    Id = Guid.NewGuid(),
                    PotionId = item.PotionId,
                    UserId = inventory.UserId,
                    BrewedOn = DateTime.Now
                };

                _brewedPotionRepository.Insert(brewedPotion);
            }

            foreach (var item in inventory.PotionsInInventory.ToList())
            {
                _inventoryItemRepository.Delete(item);
            }
        }

        public List<BrewedPotionDto> GetBrewedPotionsByUser(Guid userId)
        {
            var brewedPotions = _brewedPotionRepository.GetAll(
                selector: x => x,
                predicate: x => x.UserId == userId.ToString(),
                include: x => x.Include(bp => bp.Potion)
            ).ToList();

            return brewedPotions.Select(bp => new BrewedPotionDto
            {
                PotionId = bp.PotionId,
                PotionName = bp.Potion?.Name,
                Effect = bp.Potion?.Effect,
                ImageURL = bp.Potion?.ImageURL,
                BrewedOn = bp.BrewedOn
            }).ToList();
        }

    }
}
