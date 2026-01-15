using Potionarium.Domain.DomainModels;
using Potionarium.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potionarium.Service.Interface
{
    public interface IPotionService
    {
        List<Potion> GetAll();
        Potion? GetById(Guid Id);
        Potion Update(Potion potion);
        Potion DeleteById(Guid Id);
        Potion Add(Potion potion);
        void AddToInventory(AddPotionToInventoryDto modelDTO, Guid userId);
        Task SyncPotionsFromApi();
    }
}
