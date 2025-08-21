using Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Analysis
{
    public class RequestAnalysisDTO
    {
        public Guid? EnterpriseId { get; set; }
        public EPeriod Period { get; set; }
    }
}
