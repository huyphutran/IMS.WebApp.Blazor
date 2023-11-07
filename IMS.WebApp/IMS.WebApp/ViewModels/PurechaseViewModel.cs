using System.ComponentModel.DataAnnotations;

namespace IMS.WebApp.ViewModels
{
    public class PurechaseViewModel
    {
        [Required]
        public string PONumber { get; set; } = string.Empty;
        [Required]
        [Range(minimum:1,maximum:int.MaxValue, ErrorMessage ="You have to select an Inventory.")]
        public int InventoryId { get; set; }
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Quantity have to be greater than 1.")]

        public int QuantityToPurchase { get; set; }
        public double InventoryPrice { get; set;  }
    }
}
