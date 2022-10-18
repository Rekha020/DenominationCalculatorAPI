using System.ComponentModel.DataAnnotations;

namespace DenominationCalculatorAPI.Model
{
    public class InputCurrency
    {
        [Required(ErrorMessage = "Please Enter Amount..")]
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }


        [Required(ErrorMessage = "Please Enter Price of Product..")]
        [Display(Name = "Price of product")]
        public decimal Price { get; set; }
    }
}
