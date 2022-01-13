using IdentityService.Application.ViewModels;

namespace IdentityService.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDetailsViewModels> GetUserById(string Id, bool FromAplId = false);
    }
}
