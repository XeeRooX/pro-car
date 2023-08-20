using ProCar.Models;
using ProCar.Services;
using System.ComponentModel.DataAnnotations;

namespace ProCar.Pages.Admin.CarTypes
{
    public class CarTypeNameUnique : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string name = value!.ToString()!;
            var _context = validationContext.GetService<ICarTypeService>();
            if (!_context!.ValueExists(name))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Тип машины с таким именем уже существует");
        }
    }
}
