﻿namespace ProCar.Models
{
    // Тип привода
    public class DriveType
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<Car> Cars { get; set; } = new();

    }
}
