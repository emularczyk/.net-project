using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Forum.Models
{
    [Table("Role")]
    public class Role: IdentityRole
    {
        [Key, Required]
        public override string Id { get; set; }

        [Required]
        public override string? Name { get; set; }

        public virtual ICollection<UserRole>? UserRoles { get; set; }
    }
}