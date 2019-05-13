using Questioner.Models.Context;
using Questioner.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Questioner.Models.Repository
{
    public class OptionsRepository : IRepository<Option>
    {
        private readonly QuestionerContext _context = new QuestionerContext();

        public void Create(Option option)
        {
            _context.Options.Add(option);
            _context.SaveChanges();
        }

        public Option FirstOrDefault(Func<Option, bool> predicate)
        {
            return _context.Options.FirstOrDefault(predicate);
        }

        public Option FirstOrDefault()
        {
            throw new NotImplementedException();
        }

        public List<Option> GetOptionsForQuestion(int questionId)
        {
            return _context.Options.Where(x => x.QuestionId == questionId).ToList();
        }

        public Option Find(int id)
        {
            return _context.Options.Find(id);
        }

        public IEnumerable<Option> All()
        {
            return _context.Options.ToList();
        }
    }
}