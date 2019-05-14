using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Questioner.Models.Entity
{
    public class Statistics
    {
        public Survey Survey { get; set; }

        public IEnumerable<Question> Questions { get; set; }

        public IList<Option> Options { get; set; }

        public IList<Answer> Answers { get; set; }
    }
}