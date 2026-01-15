using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potionarium.Domain.DTO
{
    public class SpellDto
    {
        public Guid Id { get; set; }
        public string? slug { get; set; }
        public string? category { get; set; }
        public string? creator { get; set; }
        public string? effect { get; set; }
        public string? hand { get; set; }
        public string? image { get; set; }
        public string? incantation { get; set; }
        public string? light { get; set; }
        public string? name { get; set; }
        public string? wiki { get; set; }
    }
}
