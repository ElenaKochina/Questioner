using Questioner.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Questioner.Models.ViewModels
{
    public class QuestionViewModel
    {
        public int QuestionId { get; set; }

        public int? QuestionNumber { get; set; }

        public int NextQuestionNumber { get; set; }

        public string Body { get; set; }
        
        public List<Option> Options { get; set; }

        [Required (ErrorMessage = "It's a required question. You must select at least one option")]
        public List<int> SelectedOptions { get; set; }

        public bool OtherIsChecked { get; set; }

        public string Other { get; set; }

        public int QuestionType { get; set; }

        public bool Required { get; set; }

        public List<bool> AnswersCheckBox { get; set; }
    }
}