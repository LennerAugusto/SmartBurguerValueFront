using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Analysis
{
    public class TotalOrdersDTO
    {
        public string? Label { get; set; }
        public decimal? Orders { get; set; }
    }
    public class TotalOrdersResponseDTO
    {
        public List<TotalOrdersDTO>? Orders { get; set; } = new();

    }
}
