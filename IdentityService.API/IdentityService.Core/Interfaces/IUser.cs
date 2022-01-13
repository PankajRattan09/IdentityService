using IdentityService.Core.Entities;

namespace IdentityService.Core.Interfaces
{
    public interface IUser
    {
        Task<UserDetails> GetUserById(string Id,bool FromAplId = false);
    }
}
