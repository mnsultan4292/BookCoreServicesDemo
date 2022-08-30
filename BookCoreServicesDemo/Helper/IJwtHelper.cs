using BookCoreServicesDemo.Models;

namespace BookCoreServicesDemo.Helper
{
    public interface IJwtHelper
    {
        string GenerateToken(UserRegistration user);
    }
}
