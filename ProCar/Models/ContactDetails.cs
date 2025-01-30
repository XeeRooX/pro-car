namespace ProCar.Models
{
    public class ContactDetails
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string MapPoint { get; set; } = null!;
    }
}
