using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class IngredientsDTO : BaseDTO
    {
        public string Name { get; set; }
        public string? UnitOfMeasureName { get; set; }
        public Guid UnitOfMeasureId { get; set; }
        public Guid InventoryItemId { get; set; }
        public Guid? EnterpriseId { get; set; }


    }
}
