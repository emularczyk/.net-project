using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Web_Forum.Models
{
    [Table("UserRole")]
    public class UserRole: IdentityUserRole<string>
    {

        [Required, ForeignKey(nameof(User))]
        public override string UserId { get; set; }

        [Required, ForeignKey(nameof(Role))]
        public override string RoleId { get; set; }

        public virtual Role? Role { get; set; }
        public virtual User? User { get; set; }
    }
}