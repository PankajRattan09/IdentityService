namespace IdentityService.Application.ViewModels
{
    public class UserDetailsViewModels
    {
        public string UserName { get; set; }
        public string UserGuid { get; set; }
        public string RoleName { get; set; }
        public int RoleID { get; set; }
        public string AplId { get; set; }
        public bool HasActiveRole { get; set; }
    }
}
