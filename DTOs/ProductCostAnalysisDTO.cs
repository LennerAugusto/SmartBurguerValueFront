using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ProductCostAnalysisDTO : BaseDTO
    {
        public Guid ProductId { get; set; }
        public ProductsDTO Product { get; set; }
        public DateTime AnalisysDate { get; set; }
        public decimal? TotalCost { get; set; }
        public decimal? SellingPrice { get; set; }
        public decimal? SellingPriceSuggested { get; set; }
        public decimal? Markup { get; set; }
        public decimal? Margin { get; set; }
        public decimal? CPV { get; set; }
        public decimal? CMV { get; set; }
    }
}
