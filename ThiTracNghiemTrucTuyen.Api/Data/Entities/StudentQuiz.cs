using System.ComponentModel.DataAnnotations.Schema;

namespace ThiTracNghiemTrucTuyen.Api.Data.Entities
{
    public class StudentQuiz
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Guid QuizId { get; set; }

        //Thời gian bắt đầu làm bài thi trắc nghiệm
        public DateTime StartedQiz { get; set; }

        // Thời gian hoàn thành bài thi trắc nghiệm
        public DateTime EndQiz { get; set; }

        //Điểm số

        public double Score { get; set; }

        [ForeignKey(nameof(StudentId))]
        public virtual User Student { get; set; }

        [ForeignKey(nameof(QuizId))]
        public virtual Quiz Quiz { get; set; }
    }
}
