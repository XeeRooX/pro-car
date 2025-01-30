using ProCar.Models;

namespace ProCar.Services
{
    public class ContactService : IContactService
    {
        private readonly ApplicationDbContext _context;
        public ContactService(ApplicationDbContext context)
        {
            _context = context; 
        }
        public ContactDetails GetContactDetails()
        {
            return _context.ContactDetails.Find(1)!;
        }

        public List<SocialNetwork> GetSocialNetworks()
        {
            return _context.SocialNetworks.ToList();
        }
    }
}
