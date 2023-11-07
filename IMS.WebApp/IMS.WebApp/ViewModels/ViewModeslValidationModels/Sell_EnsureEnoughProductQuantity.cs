using System.ComponentModel.DataAnnotations;

namespace IMS.WebApp.ViewModels.ViewModeslValidationModels
{
    public class Sell_EnsureEnoughProductQuantity : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var sellViewModel = validationContext.ObjectInstance as SellViewModel;
            if (sellViewModel != null)
            {
                if (sellViewModel.Product != null)
                {
                  
                        if (sellViewModel.Product.Quantity < sellViewModel.ProductQuantityToSell)
                        {
                            return new ValidationResult(
                                $"There isn't enough to Sell ({sellViewModel.Product.Quantity}) in Warehouse",
                                new[] { validationContext.MemberName });
                        }
                }
            }
            return ValidationResult.Success;
        }
    }
}
