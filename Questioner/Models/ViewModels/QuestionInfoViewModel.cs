using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Questioner.Models.ViewModels
{
    public class QuestionInfoViewModel
    {
        public Dictionary<string, float> Percentage { get; set; }

        public IList<string> Options { get; set; }
    }
}