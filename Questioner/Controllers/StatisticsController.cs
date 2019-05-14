using Questioner.Models.Entity;
using Questioner.Models.Repository;
using Questioner.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Questioner.Controllers
{
    public class StatisticsController : Controller
    {
        #region [Repository]
        QuestionsRepository questionsRepository = new QuestionsRepository();
        OptionsRepository optionsRepository = new OptionsRepository();
        SurveysRepository surveysRepository = new SurveysRepository();
        #endregion

        public ActionResult Index()
        {
            var model = new Statistics();
            model.Questions = questionsRepository.All();
            return View(model);
        }

        public ActionResult QuestionInfo(int questionId = 0)
        {
            var model = new QuestionInfoViewModel();
            model.Percentage = new Dictionary<string, float>();
            var options = optionsRepository.GetOptionsForQuestion(questionId);
            foreach (var option in options)
                model.Percentage.Add(option.Body, 1);
            return View(model);
        }
    }
}