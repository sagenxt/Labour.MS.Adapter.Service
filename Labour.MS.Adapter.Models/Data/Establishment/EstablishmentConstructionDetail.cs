using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labour.MS.Adapter.Models.Data.Establishment
{
    public class EstablishmentConstructionDetail
    {
        public int? Id { get; set; }
        public decimal? ConstructionEstimatedCost { get; set; }
        public decimal? ConstructionArea { get; set; }
        public decimal? BuiltUpArea { get; set; }
        public decimal? BasicEstimatedCost { get; set; }
        public int? NoOfMaleWorkers { get; set; }
        public int? NoOfFemaleWorkers { get; set; }
    }
}
