using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberbot___st10493347_.Models
{
        public class QuizQuestion
        {
        // The text of the quiz question.
        public string Question { get; set; } = ""; 
        // A list containing all possible answer options for the question.
        public List<string> Options { get; set; } = new List<string>();
        // The correct answer to the question
        public string CorrectAnswer { get; set; } = "";
        // Provides additional information explaining why the answer is correct.
        public string Explanation { get; set; } = "";
        // Indicates whether the question is a True/False question.
        public bool IsTrueFalse { get; set; }
        }
    }
