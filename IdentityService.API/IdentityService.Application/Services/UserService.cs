using AutoMapper;
using IdentityService.Application.Interfaces;
using IdentityService.Application.ViewModels;
using IdentityService.Core.Interfaces;

namespace IdentityService.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUser _user;
        private readonly IMapper _mapper;
        public UserService(IUser user, IMapper mapper)
        {
            _user = user;
            _mapper = mapper;
        }

        public async Task<UserDetailsViewModels> GetUserById(string Id, bool FromAplId = false)
        {
            var user = await _user.GetUserById(Id, FromAplId);

            return _mapper.Map<UserDetailsViewModels>(user);
        }
    }
}
