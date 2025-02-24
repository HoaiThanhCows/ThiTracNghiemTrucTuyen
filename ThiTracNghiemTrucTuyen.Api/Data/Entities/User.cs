using System.ComponentModel.DataAnnotations;

namespace ThiTracNghiemTrucTuyen.Api.Data.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public int Name { get; set; }
        [MaxLength(100)]
        public int Email { get; set; }
        [Length(9,15)]
        public int Phone { get; set; }
        [MaxLength(250)]
        public int PasswordHash { get; set; }
        [MaxLength(10)]
        public string Role { get; set; } = nameof(UserRole.Student);


         
    }
}
