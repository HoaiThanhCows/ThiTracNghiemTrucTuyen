using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ThiTracNghiemTrucTuyen.Api.Data.Entities;

namespace ThiTracNghiemTrucTuyen.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IPasswordHasher<User> _passwordHasher;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IPasswordHasher<User> passwordHasher) : base(options)
        {
            this._passwordHasher = passwordHasher;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<StudentQuiz> StudentQuizzes { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var adminUser = new User {
                Id = 1,
                Name = "admin",
                Email = "admin@thitracnghiem.com",
                Phone = "123456789",
                Role = nameof(UserRole.Admin),
            };
            adminUser.PasswordHash = _passwordHasher.HashPassword(adminUser,"Admin12432!@%^@#");
        }
    }
}
