using Cyberbot___st10493347_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberbot___st10493347_.Services
{ 
    public class QuizManager
        {
            private readonly List<QuizQuestion> _questions;
            private int _currentIndex;
            private int _score;

            public QuizManager()
            {
                _questions = new List<QuizQuestion>
            {
                new QuizQuestion
                {
                    Question = "What should you do if you receive an email asking for your password?",
                    Options = new List<string>
                    {
                        "A) Reply with your password",
                        "B) Delete the email only",
                        "C) Report the email as phishing",
                        "D) Ignore it"
                    },
                    CorrectAnswer = "C",
                    Explanation = "Reporting phishing emails helps prevent scams and protects other users."
                },

                new QuizQuestion
                {
                    Question = "True or False: It is safe to reuse the same password on many accounts.",
                    Options = new List<string>
                    {
                        "True",
                        "False"
                    },
                    CorrectAnswer = "False",
                    Explanation = "Password reuse is risky because one leaked password can expose many accounts.",
                    IsTrueFalse = true
                },

                new QuizQuestion
                {
                    Question = "Which password is strongest?",
                    Options = new List<string>
                    {
                        "A) thabiso123",
                        "B) Password2026",
                        "C) T!ger-River-81#Cloud",
                        "D) 12345678"
                    },
                    CorrectAnswer = "C",
                    Explanation = "A strong password is long, unique, and difficult to guess."
                },

                new QuizQuestion
                {
                    Question = "What does HTTPS usually show?",
                    Options = new List<string>
                    {
                        "A) The website is using encrypted communication",
                        "B) The website is always owned by a bank",
                        "C) The website has no adverts",
                        "D) The website cannot ever be hacked"
                    },
                    CorrectAnswer = "A",
                    Explanation = "HTTPS helps protect information between your browser and the website."
                },

                new QuizQuestion
                {
                    Question = "True or False: Public Wi-Fi can be risky for logging into private accounts.",
                    Options = new List<string>
                    {
                        "True",
                        "False"
                    },
                    CorrectAnswer = "True",
                    Explanation = "Attackers may monitor unsafe public networks or create fake hotspots.",
                    IsTrueFalse = true
                },

                new QuizQuestion
                {
                    Question = "What is social engineering?",
                    Options = new List<string>
                    {
                        "A) Building secure software",
                        "B) Manipulating people into revealing information",
                        "C) Installing antivirus",
                        "D) Backing up data"
                    },
                    CorrectAnswer = "B",
                    Explanation = "Social engineering targets human behaviour instead of only technology."
                },

                new QuizQuestion
                {
                    Question = "True or False: A scammer may use urgency to pressure you into acting quickly.",
                    Options = new List<string>
                    {
                        "True",
                        "False"
                    },
                    CorrectAnswer = "True",
                    Explanation = "Urgency is a common manipulation technique used in scams.",
                    IsTrueFalse = true
                },

                new QuizQuestion
                {
                    Question = "Why should you enable two-factor authentication?",
                    Options = new List<string>
                    {
                        "A) It removes the need for passwords",
                        "B) It adds an extra layer of account protection",
                        "C) It makes Wi-Fi faster",
                        "D) It deletes malware"
                    },
                    CorrectAnswer = "B",
                    Explanation = "2FA helps protect your account even if your password is stolen."
                },

                new QuizQuestion
                {
                    Question = "True or False: Ransomware can lock files and demand payment.",
                    Options = new List<string>
                    {
                        "True",
                        "False"
                    },
                    CorrectAnswer = "True",
                    Explanation = "Ransomware blocks access to files or systems until a ransom is demanded.",
                    IsTrueFalse = true
                },

                new QuizQuestion
                {
                    Question = "Which action best protects your privacy on social media?",
                    Options = new List<string>
                    {
                        "A) Share your location publicly",
                        "B) Accept every friend request",
                        "C) Review privacy settings regularly",
                        "D) Post your phone number"
                    },
                    CorrectAnswer = "C",
                    Explanation = "Privacy settings help control who can view your information."
                },

                new QuizQuestion
                {
                    Question = "What is the best reason to keep backups?",
                    Options = new List<string>
                    {
                        "A) To recover files after loss or ransomware",
                        "B) To make phishing impossible",
                        "C) To remove all viruses automatically",
                        "D) To avoid using passwords"
                    },
                    CorrectAnswer = "A",
                    Explanation = "Backups help restore important files after accidental deletion, device failure, or ransomware."
                },

                new QuizQuestion
                {
                    Question = "Which file attachment should you treat as suspicious?",
                    Options = new List<string>
                    {
                        "A) An unexpected invoice from an unknown sender",
                        "B) Your own saved assignment",
                        "C) A document you requested from your lecturer",
                        "D) A photo you took yourself"
                    },
                    CorrectAnswer = "A",
                    Explanation = "Unexpected attachments are a common malware and phishing delivery method."
                }
            };

                _currentIndex = 0;
                _score = 0;
            }

            public QuizQuestion GetCurrentQuestion()
            {
                return _questions[_currentIndex];
            }

            public bool SubmitAnswer(string answer)
            {
                bool correct = string.Equals(
                    answer.Trim(),
                    GetCurrentQuestion().CorrectAnswer,
                    StringComparison.OrdinalIgnoreCase
                );

                if (correct)
                {
                    _score++;
                }

                _currentIndex++;

                return correct;
            }

            public bool IsFinished()
            {
                return _currentIndex >= _questions.Count;
            }

            public string GetFinalScore()
            {
                return _score + " out of " + _questions.Count;
            }

            public string GetFinalMessage()
            {
                if (_score >= 10)
                {
                    return "Great job! You understand cybersecurity very well.";
                }

                if (_score >= 7)
                {
                    return "Good work. Keep practising the areas you missed.";
                }

                return "Keep learning. Review the tips and try the quiz again.";
            }

            public void ResetQuiz()
            {
                _currentIndex = 0;
                _score = 0;
            }

            public int CurrentNumber
            {
                get { return _currentIndex + 1; }
            }

            public int TotalQuestions
            {
                get { return _questions.Count; }
            }

            public int Score
            {
                get { return _score; }
            }
        }
    }