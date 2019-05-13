using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Questioner.Models.Entity
{
    public class Option
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        public string Body { get; set; }
    }
}