using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class UnitTypesDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string BaseUnit { get; set; }
        public decimal ConversionFactor { get; set; }
    }
}
