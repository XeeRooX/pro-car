using ProCar.Validators;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace ProCar.Dtos
{

    [CarAddDtoIdExists]
    public class CarAddDto
    {
        [Required]
        public string Model { get; set; } = null!;
        [Required]
        [Range(0.0d, 10.0d, ErrorMessage = "Неверно указана величина объема двигателя")]
        public double EngineСapacity { get; set; }
        [Required]
        [Range(1900, 9999, ErrorMessage = "Неверно указан год выпуска")]
        public int YearOfIssue { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Неверно указана велечина")]
        public int CostPerDay { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Неверно указана велечина")]
        public int Deposit { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Неверно указана велечина")]
        public int TimeDelayCost { get; set; }
        [Required]
        [Range(0.0d, 10000.0d, ErrorMessage = "Неверно указана велечина")]
        public double? Horsepower { get; set; }
        [Required]
        public string? Equipment { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int GearboxTypeId { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int CarTypeId { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int DriveTypeId { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int FuelTypeId { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int BrandId { get; set; }

        [Required]
        public List<int> Colors { get; set; } = null!;
    }
}
