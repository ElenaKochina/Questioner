using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Questioner.Models.Entity
{
    public class Answer
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        public int UserId { get; set; }

        public int SelectedOption { get; set; }

        public int? NextQuestionNumber { get; set; }

        public string Other { get; set; }
    }
}