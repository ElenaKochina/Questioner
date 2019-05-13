using Questioner.Models.Entity;
using Questioner.Models.Repository;
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
        #endregion

        // GET: Statistics
        public ActionResult Index()
        {
            var model = new Statistics()
            {
                Questions = questionsRepository.All().ToList()
            };
            return View(model);
        }
    }
}