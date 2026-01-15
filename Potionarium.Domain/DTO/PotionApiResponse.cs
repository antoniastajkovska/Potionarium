using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potionarium.Domain.DTO
{
    public class PotionApiResponse
    {
        public List<PotionDataWrapper>? data { get; set; }
    }
}
