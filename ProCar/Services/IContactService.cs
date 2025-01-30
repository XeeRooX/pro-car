using ProCar.Models;

namespace ProCar.Services
{
    public interface IContactService
    {
        public List<SocialNetwork> GetSocialNetworks();
        public ContactDetails GetContactDetails();
    }
}
