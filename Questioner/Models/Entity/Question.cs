using Questioner.Models.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Questioner.Models.Entity
{
    public class Question
    {
        public int Id { get; set; }

        public int SurveyId { get; set; }

        public int QuestionNumber { get; set; }

        public int NextQuestionNumber { get; set; }

        public QuestionType Type { get; set; }

        public string Body { get; set; }

        public List<string> Options { get; set; }

        public bool Required { get; set; }
    }
}