using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ComboDTO : BaseDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public decimal? SellingPrice { get; set; }
        public decimal? SugestedPrice { get; set; }
        public decimal? CPV { get; set; }
        public decimal? CMV { get; set; }
        public decimal? Markup { get; set; }
        public decimal? Margin { get; set; }
        public decimal? DesiredMargin { get; set; }
        public Guid EnterpriseId { get; set; }
        public List<ProductsDTO> Products { get; set; }
    }
}
