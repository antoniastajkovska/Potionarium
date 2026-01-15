using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potionarium.Domain.DTO
{
    public class SpellApiResponse
    {
        public List<SpellDataWrapper>? data { get; set; }
    }
}
