using Questioner.Models.Context;
using Questioner.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Questioner.Models.Repository
{
    public class QuestionsRepository : IRepository<Question>
    {
        private readonly QuestionerContext _context = new QuestionerContext();

        public void Create(Question question)
        {
            _context.Questions.Add(question);
            _context.SaveChanges();
        }

        public int GetQuestionId()
        {
            return _context.Questions.OrderByDescending(p => p.Id).FirstOrDefault().Id;
        }

        public Question FirstOrDefault(Func<Question, bool> predicate)
        {
            return _context.Questions.FirstOrDefault(predicate);
        }

        public Question FirstOrDefault()
        {
            throw new NotImplementedException();
        }

        public Question Find(int? questionNumber, int surveyId)
        {
            if (questionNumber != 0)
            {
                var entityId = _context.Questions
                    .Where(x => x.SurveyId == surveyId)
                    .Where(x => x.QuestionNumber == questionNumber).FirstOrDefault().Id;
                return _context.Questions.Find(entityId);
            }
            return null;
        }

        public Question Find(int id)
        {
            return _context.Questions.Find(id);
        }

        public IEnumerable<Question> All()
        {
            return _context.Questions.ToList();
        }
    }
}