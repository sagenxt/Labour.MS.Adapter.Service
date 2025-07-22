using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labour.MS.Adapter.Models.DTOs.Response.Worker
{
    public class WorkerCardDetailsResponse
    {
        public int PresentDays { get; set; }
        public int AbsentDays { get; set; }
        public int TotalDays { get; set; }
    }
}
