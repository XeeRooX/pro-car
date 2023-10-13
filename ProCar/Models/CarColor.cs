using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ProCar.Models
{
   
    public class CarColor
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; } = null!;
        public int ColorId { get; set; }
        public Color Color { get; set; } = null!;
    }
}
