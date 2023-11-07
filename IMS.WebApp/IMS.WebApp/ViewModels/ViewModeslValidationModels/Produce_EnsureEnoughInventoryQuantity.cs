using System.ComponentModel.DataAnnotations;

namespace IMS.WebApp.ViewModels.ViewModeslValidationModels
{
    public class Produce_EnsureEnoughInventoryQuantity : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var produceViewModel = validationContext.ObjectInstance as ProduceViewModel;
            if (produceViewModel != null)
            {
                if(produceViewModel.Product != null)
                {
                    foreach(var pi in produceViewModel.Product.ProductInventories)
                    {
                        if(pi.Inventory != null && 
                            pi.InventoryQuantity *  produceViewModel.QuantityToProduce > pi.Inventory.Quantity)
                        {
                            return new ValidationResult(
                                $"The inventory({pi.Inventory.IventoryName}) is not enough to Produce {produceViewModel.QuantityToProduce} products",
                                new[] { validationContext.MemberName });
                        }
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}
