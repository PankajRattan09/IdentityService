using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityService.Core.Entities
{
    public class UserDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserGuid { get; set; }
        public string RoleName { get; set; }
        public int RoleID { get; set; }
        public string AplId { get; set; }
        public bool HasActiveRole { get; set; }
    }
}
