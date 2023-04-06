using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Forum.Models
{
    [Table("user")]
    public class User: IdentityUser
    {
        [Key, Required]
        [NotMapped]
        public override string Id { get => base.Id; set => base.Id = value; }

        [Required]
        public override string Email { get => base.Email; set => base.Email = value; }

        [Required]
        [Column("password")]
        public override string PasswordHash { get => base.PasswordHash; set => base.PasswordHash = value; }

        [Required]
        [Column("nickname")]
        public override string UserName { get => base.UserName; set => base.UserName = value; }

        public virtual ICollection<UserRole> UserRoles { get; set; }

        [NotMapped]
        public override DateTimeOffset? LockoutEnd { get => base.LockoutEnd; set => base.LockoutEnd = value; }

        [NotMapped]
        public override int AccessFailedCount { get => base.AccessFailedCount; set => base.AccessFailedCount = value; }

        [NotMapped]
        public override string ConcurrencyStamp { get => base.ConcurrencyStamp; set => base.ConcurrencyStamp = value; }

        [NotMapped]
        public override bool EmailConfirmed { get => base.EmailConfirmed; set => base.EmailConfirmed = value; }

        [NotMapped]
        public override bool LockoutEnabled { get => base.LockoutEnabled; set => base.LockoutEnabled = value; }

        [NotMapped]
        public override string NormalizedEmail { get => base.NormalizedEmail; set => base.NormalizedEmail = value; }

        [NotMapped]
        public override string NormalizedUserName { get => base.NormalizedUserName; set => base.NormalizedUserName = value; }

        [NotMapped]
        public override string PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }

        [NotMapped]
        public override bool PhoneNumberConfirmed { get => base.PhoneNumberConfirmed; set => base.PhoneNumberConfirmed = value; }

        [NotMapped]
        public override string SecurityStamp { get => base.SecurityStamp; set => base.SecurityStamp = value; }

        [NotMapped]
        public override bool TwoFactorEnabled { get => base.TwoFactorEnabled; set => base.TwoFactorEnabled = value; }

    }
}
