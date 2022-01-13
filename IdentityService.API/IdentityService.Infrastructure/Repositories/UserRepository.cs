using IdentityService.Core.Entities;
using IdentityService.Core.Interfaces;
using IdentityService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Infrastructure.Repositories
{
    public class UserRepository : IUser
    {
        private readonly UserContext _userContext;
        public UserRepository(UserContext userContext) => _userContext = userContext;
        public async Task<UserDetails> GetUserById(string Id, bool FromAplId = false)
        {
            if (FromAplId)
                return await _userContext.User_Detail.FirstOrDefaultAsync(u => u.AplId == Id);

            return await _userContext.User_Detail.FirstOrDefaultAsync(u => u.UserGuid == Id);
        }
    }
}
