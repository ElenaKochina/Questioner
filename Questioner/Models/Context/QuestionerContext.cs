using Questioner.Models.Entity;
using System.Data.Entity;

namespace Questioner.Models.Context
{
    public class QuestionerContext : DbContext
    {
        public QuestionerContext()
            : base("QuestionerContext")
        {
        }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<Option> Options { get; set; }

        public DbSet<Survey> Surveys { get; set; }

        public DbSet<User> Users { get; set; }
    }
}