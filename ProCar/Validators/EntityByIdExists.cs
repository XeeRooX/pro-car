using ProCar.Dtos;
using ProCar.Models;
using ProCar.Services;
using System.ComponentModel.DataAnnotations;

namespace ProCar.Validators
{

    public class CarAddDtoIdExists : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            CarAddDto carAddDto = (CarAddDto)value!;
            ApplicationDbContext _context = validationContext.GetService<ApplicationDbContext>()!;

            if (_context.GearboxTypes.Find(carAddDto.GearboxTypeId) == null ||
                _context.CarTypes.Find(carAddDto.CarTypeId) == null || 
                _context.DriveTypes.Find(carAddDto.DriveTypeId) == null ||
                _context.FuelTypes.Find(carAddDto.FuelTypeId) == null || 
                _context.Brands.Find(carAddDto.BrandId) == null)
            {
                Console.WriteLine("Value with current Id in CarAddDto is not Exists");
                return new ValidationResult("Value with current Id in CarAddDto is not Exists");
            }
            return ValidationResult.Success;
        }
    }
}
