using IdentityService.Application.ViewModels;
using System.Collections.Generic;

namespace IdentityService.API.Test.Entities
{
    public class TestDataProviderForGetUserById
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
                    }), "eyJVc2VyTmFtZSI6IlBhbmthaiBLdW1hciIsIlVzZXJHdWlkIjoidGVzdCIsIlJvbGVOYW1lIjoiYWRtaW4iLCJSb2xlSUQiOjEsIkFwbElkIjoiMSIsIkhhc0FjdGl2ZVJvbGUiOnRydWV9"
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
                    }),"eyJVc2VyTmFtZSI6IkFraGlsIiwiVXNlckd1aWQiOiJ0ZXN0MSIsIlJvbGVOYW1lIjoiVXNlciIsIlJvbGVJRCI6MiwiQXBsSWQiOiIyIiwiSGFzQWN0aXZlUm9sZSI6dHJ1ZX0="
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
                    }), "eyJVc2VyTmFtZSI6IlJhbWFuIiwiVXNlckd1aWQiOiJ0ZXN0MyIsIlJvbGVOYW1lIjoiQW5vbiIsIlJvbGVJRCI6MywiQXBsSWQiOiIzIiwiSGFzQWN0aXZlUm9sZSI6dHJ1ZX0="
            };
        }
    }
}
