using Questioner.Models.Context;
using Questioner.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Questioner.Models.Repository
{
    public class AnswersRepository : IRepository<Answer>
    {
        private readonly QuestionerContext _context = new QuestionerContext();

        public void Create(Answer answer)
        {
            _context.Answers.Add(answer);
            _context.SaveChanges();
        }

        public void DeleteIfExists(int userId, int questionId)
        {
            var answers = _context.Answers.Where(x => x.UserId == userId && x.QuestionId == questionId);
            if (answers.Any())
                _context.Answers.RemoveRange(answers);
        }

        public Answer FirstOrDefault(Func<Answer, bool> predicate)
        {
            return _context.Answers.FirstOrDefault(predicate);
        }

        public Answer FirstOrDefault()
        {
            throw new NotImplementedException();
        }

        public Answer Find(int id)
        {
             return _context.Answers.Find(id);
        }

        public IEnumerable<Answer> All()
        {
            return _context.Answers.ToList();
        }
    }
}