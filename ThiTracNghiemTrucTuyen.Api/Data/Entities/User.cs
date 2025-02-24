using System.ComponentModel.DataAnnotations;

namespace ThiTracNghiemTrucTuyen.Api.Data.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
        [MaxLength(100)]
        public string? Email { get; set; }
        [Length(9,15)]
        public string? Phone { get; set; }
        [MaxLength(250)]
        public string? PasswordHash { get; set; }
        [MaxLength(10)]
        public virtual string Role { get; set; } = nameof(UserRole.Student);


         
    }
}
