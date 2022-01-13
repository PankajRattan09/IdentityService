using AutoMapper;
using IdentityService.Application.ViewModels;
using IdentityService.Core.Entities;

namespace IdentityService.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDetails, UserDetailsViewModels>();
        }
    }
}
