using Questioner.Models.Context;
using Questioner.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Questioner.Models.Repository
{
    public class SurveysRespository : IRepository<Survey>
    {
        private readonly QuestionerContext _context = new QuestionerContext();

        public void Create(Survey survey)
        {
            _context.Surveys.Add(survey);
            _context.SaveChanges();
        }

        public int GetCurrentId()
        {
            return _context.Surveys.OrderByDescending(p => p.Id).FirstOrDefault().Id;
        }

        //looks for survey with the same NUMBER that's given in json. NOT ID.
        public bool SurveyNotExists(Survey survey)
        {
            return _context.Surveys.Where(x => x.SurveyNumber == survey.SurveyNumber).FirstOrDefault() == null;
        }

        public Survey FirstOrDefault(Func<Survey, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Survey FirstOrDefault()
        {
            return _context.Surveys.FirstOrDefault();
        }

        public Survey Find(int id)
        {
            return _context.Surveys.Find(id);
        }

        public IEnumerable<Survey> All()
        {
            throw new NotImplementedException();
        }
    }
}