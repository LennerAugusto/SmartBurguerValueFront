using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constants
{
    public class DailyEntryItemsDTO :BaseDTO
    {
        public Guid? Id { get; set; }
        public Guid? DailyEntryId { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? ComboId { get; set; } = Guid.Empty;
        public string? Name { get; set; } = string.Empty;
        public decimal? Quantity { get; set; }
        public decimal? TotalRevenue { get; set; }
        public decimal? TotalCPV { get; set; }
    }
}
