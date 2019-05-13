using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Questioner.Models.ViewModels
{
    public class AnswerTextBoxViewModel
    {
        public int QuestionId { get; set; }

        public int? QuestionNumber { get; set; }

        public int NextQuestionNumber { get; set; }

        public string Body { get; set; }

        [Required (ErrorMessage = "This field can't be empty")]
        public string Other { get; set; }

        public int QuestionType { get; set; }
    }
}