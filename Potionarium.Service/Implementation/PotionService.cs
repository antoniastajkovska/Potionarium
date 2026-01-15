using Microsoft.IdentityModel.Tokens;
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
    public class PotionService : IPotionService
    {
        private readonly IRepository<Potion> _potionRepository;
        private readonly IFetchAPIService _fetchPotionsService;
        private readonly IInventoryService _inventoryService;
        private readonly IRepository<InventoryItem> _inventoryItemRepository;

        public PotionService(IRepository<Potion> potionRepository, IFetchAPIService fetchPotionsService, IInventoryService inventoryService, IRepository<InventoryItem> inventoryItemRepository)
        {
            _potionRepository = potionRepository;
            _fetchPotionsService = fetchPotionsService;
            _inventoryService = inventoryService;
            _inventoryItemRepository = inventoryItemRepository;
        }

        public Potion Add(Potion potion)
        {
            potion.Id = Guid.NewGuid();
            return _potionRepository.Insert(potion);
        }

        public void AddToInventory(AddPotionToInventoryDto modelDTO, Guid userId)
        {
            var inventory = _inventoryService.GetByUserId(userId);
            var potion = _potionRepository.Get(selector: x => x,
                predicate: x => x.Id == modelDTO.PotionId);

            var existing = _inventoryItemRepository.Get(selector: x => x,
                predicate: x => x.PotionId == modelDTO.PotionId && x.InventoryID == inventory.Id);

            if (existing == null)
            {
                InventoryItem newPotion = new InventoryItem
                {
                    Id = Guid.NewGuid(),
                    Potion = potion,
                    PotionId = modelDTO.PotionId,
                    Inventory = inventory,
                    InventoryID = inventory.Id,
                    Quantity = modelDTO.Quantity
                };

                _inventoryItemRepository.Insert(newPotion);
            }
            else
            {
                existing.Quantity += modelDTO.Quantity;
                _inventoryItemRepository.Update(existing);
            }
        }

        public Potion DeleteById(Guid Id)
        {
            var potion = _potionRepository.Get(selector: x => x,
                predicate: x => x.Id == Id);
            return _potionRepository.Delete(potion);
        }

        public List<Potion> GetAll()
        {
            return _potionRepository.GetAll(selector: x => x).ToList();
        }

        public Potion? GetById(Guid Id)
        {
            return _potionRepository.Get(selector: x => x,
                                            predicate: x => x.Id == Id);
        }

        public async Task SyncPotionsFromApi()
        {
            var apiPotions = await _fetchPotionsService.GetAllPotionsAsync();

            foreach (var apiPotion in apiPotions)
            {
                var exists = GetAll()
                    .Any(p => p.Id == apiPotion.Id);

                if (!exists)
                {
                    var newPotion = new Potion
                    {
                        Id = apiPotion.Id,
                        Name = apiPotion.name,
                        Difficulty = apiPotion.difficulty,
                        Effect = apiPotion.effect,
                        ImageURL = apiPotion.image,
                        DetailsLink = apiPotion.wiki,
                        IsFromApi = true
                    };

                    _potionRepository.Insert(newPotion);
                }
            }
        }

        public Potion Update(Potion potion)
        {
            return _potionRepository.Update(potion);
        }
    }
}
