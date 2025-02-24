using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThiTracNghiemTrucTuyen.Api.Data.Entities
{
    public class Question
    {
        [Key]
        public int Int { get; set; }
        public string? Text { get; set; }
        public Guid QuizId { get; set; }
        [ForeignKey(nameof(QuizId))]
        public virtual Quiz? Quiz { get; set; }
    }
}
