using Potionarium.Domain.DomainModels;
using Potionarium.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potionarium.Service.Interface
{
    public interface IInventoryService 
    {
        Inventory GetByUserId(Guid id);
        InventoryDto GetByUserIdIncudingPotions(Guid id);
        AddPotionToInventoryDto GetPotionInfo(Guid id);
        Boolean RemoveFromInventory(Guid id, string userId);
        void BrewPotions(Guid userId);
        List<BrewedPotionDto> GetBrewedPotionsByUser(Guid userId);
    }
}
