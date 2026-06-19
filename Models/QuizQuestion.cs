using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberbot___st10493347_.Models
{
        public class QuizQuestion
        {
            public string Question { get; set; } = "";
            public List<string> Options { get; set; } = new List<string>();
            public string CorrectAnswer { get; set; } = "";
            public string Explanation { get; set; } = "";
            public bool IsTrueFalse { get; set; }
        }
    }
