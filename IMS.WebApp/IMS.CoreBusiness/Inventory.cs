using IMS.CoreBusiness.Validations;
using System.ComponentModel.DataAnnotations;

namespace IMS.CoreBusiness
{
    public class Inventory
    {
        public int InventoryId { get; set; }
        [Required]
        [StringLength(100)]
        public string IventoryName { get; set; } = string.Empty;
        [Range(0, int.MaxValue, ErrorMessage="Quantity must be greater or equal to 0" )]
        public int Quantity { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Price must be greater or equal to 0")]

        [Product_EnsurePriceIsGreaterThanInventoriesCost]
        public List<ProductInventory> ProductInventories { get; set; } = new List<ProductInventory>();
        public double Price { get; set; }

    }
}