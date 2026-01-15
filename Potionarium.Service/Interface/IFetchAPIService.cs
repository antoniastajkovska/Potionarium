using Potionarium.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potionarium.Service.Interface
{
    public interface IFetchAPIService
    {
        Task<List<PotionDto>> GetAllPotionsAsync();
        Task<List<SpellDto>> GetAllSpellsAsync();
    }
}
