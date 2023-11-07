using IMS.CoreBusiness;
using IMS.WebApp.ViewModels.ViewModeslValidationModels;
using System.ComponentModel.DataAnnotations;
using Xunit.Abstractions;

namespace IMS.WebApp.ViewModels
{
    public class SellViewModel
    {
        public string SalesOrderNumber { get; set; }
        public int ProductId { get; set; }
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Quantity have to be greater than 1.")]
        [Sell_EnsureEnoughProductQuantity]
        public int ProductQuantityToSell { get; set; }
        [Required]
        [Range(minimum: 0, maximum: int.MaxValue, ErrorMessage = "Price has to be Greater than 0")]
        public double UnitPrice { get; set; }

        public Product? Product { get; set; } = null;
    }
}
