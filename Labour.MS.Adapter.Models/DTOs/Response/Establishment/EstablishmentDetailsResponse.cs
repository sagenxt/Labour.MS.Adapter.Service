using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labour.MS.Adapter.Models.Data.Common;
using Labour.MS.Adapter.Models.Data.Establishment;

namespace Labour.MS.Adapter.Models.DTOs.Response.Establishment
{
    public class EstablishmentDetailsResponse : EstablishmentDetail
    {
        public string? StateName { get; set; }
        public string? DistrictName { get; set; }
        public string? CityName { get; set; }
        public string? VillageOrAreaName { get; set; }
        public string? CategoryName { get; set; }
        public string? WorkNatureName { get; set; }
       
    }
}
