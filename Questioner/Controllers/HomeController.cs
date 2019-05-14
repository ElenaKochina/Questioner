using Newtonsoft.Json;
using Questioner.Models;
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
    public class HomeController : Controller
    {
        #region [Repository]
        QuestionsRepository questionsRepository = new QuestionsRepository();
        OptionsRepository optionsRepository = new OptionsRepository();
        AnswersRepository answersRepository = new AnswersRepository();
        SurveysRepository SurveysRepository = new SurveysRepository();
        UsersRespository usersRespository = new UsersRespository();
        #endregion

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Finished()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Question(int? questionNumber)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Authentication");

            if (questionNumber == null)
            {
                ReadJson();
                questionNumber = 1;
            }

            var surveyId = SurveysRepository.GetCurrentId();
            var question = questionsRepository.Find(questionNumber, surveyId);

            if(question == null)
                return View("Finished");

            var options = optionsRepository.GetOptionsForQuestion(question.Id);

            var model = new QuestionViewModel();
            model.QuestionId = question.Id;
            model.QuestionNumber = questionNumber;
            model.Options = options;
            model.QuestionType = (int)question.Type;
            model.NextQuestionNumber = question.NextQuestionNumber;
            model.Body = question.Body;
            model.Required = question.Required;

            return View(model);
        }

        [HttpPost]
        public ActionResult Answer(QuestionViewModel answer)
        {
            if (!ModelState.IsValid && answer.Other == null)
            {
                if (!answer.Required)
                    return RedirectToAction("Question", "Home", new { questionNumber = answer.NextQuestionNumber });
                answer.Options = optionsRepository.GetOptionsForQuestion(answer.QuestionId);
                return View("Question", answer);
            }
            else
            {
                //if this user has already answered this question, delete his previous answer
                answersRepository.DeleteIfExists(usersRespository.GetId(User.Identity.Name), answer.QuestionId);

                if (answer.SelectedOptions != null)
                {
                    foreach (var option in answer.SelectedOptions)
                    {
                        Answer answerEntity = new Answer() // move to modelbuilder
                        {
                            NextQuestionNumber = answer.NextQuestionNumber,
                            QuestionId = answer.QuestionId,
                            SelectedOption = option,
                            Other = answer.Other,
                            UserId = usersRespository.GetId(User.Identity.Name)
                        };
                        answersRepository.Create(answerEntity);
                    }
                }
                else
                {
                    Answer answerEntity = new Answer() // move to modelbuilder
                    {
                        NextQuestionNumber = answer.NextQuestionNumber,
                        QuestionId = answer.QuestionId,
                        Other = answer.Other,
                        UserId = usersRespository.GetId(User.Identity.Name)
                    };
                    answersRepository.Create(answerEntity);
                }
                return RedirectToAction("Question", "Home", new { questionNumber = answer.NextQuestionNumber });
            }
        }

        [HttpPost]
        public ActionResult Video(QuestionViewModel answer)
        {
            return RedirectToAction("Question", "Home", new { questionNumber = answer.NextQuestionNumber});
        }

        [HttpPost]
        public ActionResult Text(AnswerTextBoxViewModel answer)
        {
            if (ModelState.IsValid)
            {
                answersRepository.DeleteIfExists(usersRespository.GetId(User.Identity.Name), answer.QuestionId);

                Answer answerEntity = new Answer()
                {
                    NextQuestionNumber = answer.NextQuestionNumber,
                    QuestionId = answer.QuestionId,
                    Other = answer.Other,
                    UserId = usersRespository.GetId(User.Identity.Name)
                };
                answersRepository.Create(answerEntity);
                return RedirectToAction("Question", "Home", new { questionNumber = answer.NextQuestionNumber });
            }
            else
            {
                var model = new QuestionViewModel()
                {
                    Body = answer.Body,
                    Other = answer.Other,
                    QuestionNumber = answer.QuestionNumber,
                    QuestionType = answer.QuestionType,
                    NextQuestionNumber = answer.NextQuestionNumber,
                    QuestionId = answer.QuestionId
                };
                return View("Question", model);
            }
        }

        public void ReadJson()
        {
            var json = System.IO.File.ReadAllText(Server.MapPath(@"~/Question.json"));
            var survey = JsonConvert.DeserializeObject<Survey>(json);
            if (SurveysRepository.SurveyNotExists(survey))
            {
                SurveysRepository.Create(survey);

                var surveyId = SurveysRepository.GetCurrentId();
                var questions = survey.Questions;

                foreach (var question in questions)
                {
                    if (question.Type != Models.Util.QuestionType.TextBox & question.Type != Models.Util.QuestionType.Video)
                    {
                        foreach (var opt in question.Options)
                        {
                            Option option = new Option()
                            {
                                Body = opt,
                                QuestionId = question.Id
                            };
                            optionsRepository.Create(option);
                        }
                    }
                }
            }
        }
    }
}