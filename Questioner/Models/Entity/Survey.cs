using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Questioner.Models.Entity
{
    public class Survey
    {
        public int Id { get; set; }

        public int SurveyNumber { get; set; }

        public string SurveyTitle { get; set; }

        public List<Question> Questions { get; set; }
    }
}