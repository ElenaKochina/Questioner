using Questioner.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Questioner.Models.ViewModels
{
    public class StatisticsViewModel
    {
        public IList<Question> Questions { get; set; }
    }
}