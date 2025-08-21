using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Analysis
{
    public class BestSellingProductsDTO
    {
        public Guid EnterpriseID { get; set; }
        public string Name { get; set; } 
        public int Quantity { get; set; }
        public decimal SellingPrice { get; set; }
        public string ImageUrl { get; set; }
        public Guid ProductId { get; set; }
    }
}
