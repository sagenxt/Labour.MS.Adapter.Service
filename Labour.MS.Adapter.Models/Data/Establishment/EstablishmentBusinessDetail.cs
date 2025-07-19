using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labour.MS.Adapter.Models.Data.Establishment
{
    public class EstablishmentBusinessDetail
    {
        public int? Id { get; set; }
        public string? IsPlanApprovalId { get; set; }
        public string? PlanApprovalId { get; set; }
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int? WorkNatureId { get; set; }
        public string? WorkNatureName { get; set; }
        public DateOnly? CommencementDate { get; set; }
        public DateOnly? CompletionDate { get; set; }
    }
}
