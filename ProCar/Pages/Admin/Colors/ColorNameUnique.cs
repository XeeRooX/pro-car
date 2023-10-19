using ProCar.Models;
using ProCar.Services;
using System.ComponentModel.DataAnnotations;

namespace ProCar.Pages.Admin.CarTypes
{
    public class ColorNameUnique : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string name = value!.ToString()!;
            var _context = validationContext.GetService<IColorService>();
            if (_context!.ElementExists(name) != 0)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Цвет машины с таким именем уже существует");
        }
    }
}
