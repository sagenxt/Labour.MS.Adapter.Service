using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labour.MS.Adapter.Models.Data.Masters
{
    public class VillageAreaDetail
    {
        public long? VillageId { get; set; }
        public string? VillageName { get; set; }
        public string? VillageCode { get; set; }
        public long? CityId { get; set; }
        public string? CityName { get; set; }
    }
}
