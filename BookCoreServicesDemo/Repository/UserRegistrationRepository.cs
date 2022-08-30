using BookCoreServicesDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCoreServicesDemo.Repository
{
    public class UserRegistrationRepository : IUserRegistrationRepository
    {
        BookDBContext _dbContext;
        public UserRegistrationRepository(BookDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UserRegistration>> GetUserDetails()
        {
            if (_dbContext != null)
            {
                return await _dbContext.UserRegistrations.ToListAsync();
            }
            return null;
        }
    }
}
