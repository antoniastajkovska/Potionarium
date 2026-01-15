using Newtonsoft.Json;
using Potionarium.Domain.DTO;
using Potionarium.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potionarium.Service.Implementation
{
    public class FetchAPIService : IFetchAPIService
    {
        private readonly HttpClient _httpClient;

        public FetchAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PotionDto>> GetAllPotionsAsync()
        {

            var response = await _httpClient.GetAsync("https://api.potterdb.com/v1/potions");
            if (!response.IsSuccessStatusCode)
            {
                return new List<PotionDto>();
            }

            var json = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<PotionApiResponse>(json);

            return apiResponse?.data.Select(w => new PotionDto
            {
                Id = w.id,
                slug = w.attributes.slug,
                characteristics = w.attributes.characteristics,
                difficulty = w.attributes.difficulty,
                effect = w.attributes.effect,
                image = w.attributes.image,
                inventors = w.attributes.inventors,
                ingredients = w.attributes.ingredients,
                manufacturers = w.attributes.manufacturers,
                side_effects = w.attributes.side_effects,
                time = w.attributes.time,
                wiki = w.attributes.wiki,
                name = w.attributes.name,
            }).ToList();
        }

        public async Task<List<SpellDto>> GetAllSpellsAsync()
        {
            var response = await _httpClient.GetAsync("https://api.potterdb.com/v1/spells");

            if (!response.IsSuccessStatusCode)
            {
                return new List<SpellDto>();
            }

            var json = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<SpellApiResponse>(json);

            return apiResponse?.data.Select(w => new SpellDto
            {
                Id = w.Id,
                slug = w.attributes.slug,
                category = w.attributes.category,
                creator = w.attributes.creator,
                effect = w.attributes.effect,
                hand = w.attributes.hand,
                image = w.attributes.image,
                incantation = w.attributes.incantation,
                light = w.attributes.light,
                name = w.attributes.name,
                wiki = w.attributes.wiki
            }).ToList();
        }
    }
}
