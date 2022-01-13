using IdentityService.Application.ViewModels;
using System.Collections.Generic;

namespace IdentityService.API.Test.Entities
{
    public class TestDataProviderForGetUserByUserId
    {
        public static IEnumerable<object[]> TestCases()
        {
            yield return new object[]
            {
                    "1", new MemberDataSerializer<UserDetailsViewModels>(new UserDetailsViewModels{
                          UserName = "Pankaj Kumar",
                          UserGuid = "test",
                          RoleName = "admin",
                          RoleID = 1,
                          AplId = "1",
                          HasActiveRole = true
                    }), new MemberDataSerializer<UserDetailsViewModels>(new UserDetailsViewModels{
                          UserName = "Pankaj Kumar",
                          UserGuid = "test",
                          RoleName = "admin",
                          RoleID = 1,
                          AplId = "1",
                          HasActiveRole = true
                    })
            };
            yield return new object[]
            {
                    "2", new MemberDataSerializer<UserDetailsViewModels>(new UserDetailsViewModels{
                          UserName = "Akhil",
                          UserGuid = "test1",
                          RoleName = "User",
                          RoleID = 2,
                          AplId = "2",
                          HasActiveRole = true
                    }), new MemberDataSerializer<UserDetailsViewModels>(new UserDetailsViewModels{
                          UserName = "Akhil",
                          UserGuid = "test1",
                          RoleName = "User",
                          RoleID = 2,
                          AplId = "2",
                          HasActiveRole = true
                    })
            };
            yield return new object[]
            {
                    "3", new MemberDataSerializer<UserDetailsViewModels>(new UserDetailsViewModels{
                          UserName = "Raman",
                          UserGuid = "test3",
                          RoleName = "Anon",
                          RoleID = 3,
                          AplId = "3",
                          HasActiveRole = true
                    }), new MemberDataSerializer<UserDetailsViewModels>(new UserDetailsViewModels{
                          UserName = "Raman",
                          UserGuid = "test3",
                          RoleName = "Anon",
                          RoleID = 3,
                          AplId = "3",
                          HasActiveRole = true
                    })
            };
        }
    }

}
