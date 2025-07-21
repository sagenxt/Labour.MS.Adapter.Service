using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labour.MS.Adapter.Models.Data.Worker
{
    public class DependentDetail
    {
        public string? DependentName { get; set; }
        public string? DateOfBirth { get; set; }
        public string? Relationship { get; set; }
        public bool? IsNomineeSelected { get; set; }
        public decimal? PercentageOfBenifits { get; set; }
    }
}
