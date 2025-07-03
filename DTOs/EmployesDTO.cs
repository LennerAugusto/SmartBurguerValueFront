using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class EmployesDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string? EmploymentType { get; set; }
        public Guid? EnterpriseId { get; set; }
        public Decimal? MonthlySalary { get; set; }
        public List<WorkSchedulesDTO>? WorkSchedules { get; set; } = new List<WorkSchedulesDTO>();
    }
    public class WorkSchedulesDTO
    {
        public string? Weekday { get; set; }
        public decimal? DailyRate { get; set; }
    }
}
