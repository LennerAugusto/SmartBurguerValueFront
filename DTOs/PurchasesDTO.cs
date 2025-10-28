using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class PurchasesDTO : BaseDTO
    {
        public string SupplierName { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal TotalAmount { get; set; }
        public Guid? EnterpriseId { get; set; }
        public List<PurchaseItemsDTO> Items { get; set; } = new List<PurchaseItemsDTO>();

    }
    public class PurchaseItemsDTO
    {
        public string NameItem { get; set; }
        public Guid PurchaseId { get; set; }
        public Guid UnityOfMensureId { get; set; }
        public string UnityOfMensureSymbol { get; set; }
        public Guid? InventoryItemId { get; set; }
        public Guid? IngredientId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal  Quantity { get; set; }
    }
}
