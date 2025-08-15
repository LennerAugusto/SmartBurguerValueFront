using Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DailyEntryDTO : BaseDTO
    {
        public Guid DailyEntryId { get; set; }
        public DateTime EntryDate { get; set; }
        public decimal Revenue { get; set; }
        public string? Description { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalItems { get; set; }
        public decimal Liquid { get; set; }
        public Guid EnterpriseId { get; set; }
        public List<DailyEntryItemsDTO> Items { get; set; } = new List<DailyEntryItemsDTO>(); 

    }
}
