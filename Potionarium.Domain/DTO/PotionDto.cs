using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potionarium.Domain.DTO
{
    public class PotionDto
    {
        public Guid Id { get; set; }
        public string? slug { get; set; }
        public string? characteristics { get; set; }
        public string? difficulty { get; set; }
        public string? effect { get; set; }
        public string? image { get; set; }
        public string? inventors { get; set; }
        public string? ingredients { get; set; }
        public string? manufacturers { get; set; }
        public string? side_effects { get; set; }
        public string? time { get; set; }
        public string? wiki { get; set; }
        public string? name { get; set; }
    }

}
