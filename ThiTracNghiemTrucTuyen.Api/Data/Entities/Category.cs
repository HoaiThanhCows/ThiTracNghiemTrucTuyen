using System.ComponentModel.DataAnnotations;

namespace ThiTracNghiemTrucTuyen.Api.Data.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
