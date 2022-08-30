using BookCoreServicesDemo.Models;
namespace BookCoreServicesDemo.Repository
{
    public interface IUserRegistrationRepository
    {
        Task<List<UserRegistration>> GetUserDetails();
    }
}
