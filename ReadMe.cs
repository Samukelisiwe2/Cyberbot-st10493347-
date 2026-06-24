namespace Cyberbot___st10493347_
{
    /// <summary>
    /// Project documentation for the Cybersecurity Awareness Chatbot.
    /// </summary>
    internal static class ReadMe
    {
        public const string ProjectInformation = @"
====================================================
CYBERSECURITY AWARENESS CHATBOT
====================================================

PROJECT OVERVIEW
----------------
The Cybersecurity Awareness Chatbot is a desktop application
developed using C# and Windows Presentation Foundation (WPF).

The purpose of the application is to educate users about
cybersecurity concepts while providing interactive features
such as task management, reminders, quizzes, and activity
tracking.

The chatbot acts as a virtual cybersecurity assistant that
helps users learn about important topics including phishing,
malware, password security, online privacy, safe browsing,
ransomware, firewalls, public Wi-Fi security, and
two-factor authentication (2FA).

FEATURES
--------

1. Interactive Chatbot
- Greets users and asks for their name.
- Stores user information during the session.
- Responds to cybersecurity-related questions.
- Supports follow-up questions such as:
  * Why?
  * How?
  * Give me an example.
  * Tell me more.
- Detects user sentiment and provides appropriate responses.

2. Cybersecurity Knowledge Base
The chatbot can explain:
- Password Security
- Phishing Attacks
- Malware
- Online Scams
- Privacy Protection
- Safe Browsing
- Ransomware
- Two-Factor Authentication (2FA)
- Public Wi-Fi Risks
- Firewalls

3. Task Assistant
Users can:
- Create cybersecurity-related tasks.
- Set reminders.
- Mark tasks as completed.
- Delete tasks.
- View all stored tasks.

4. Activity Logging
The system automatically records:
- Task creation
- Task completion
- Task deletion
- Reminder updates
- Quiz activities

Users can view recent activities or the complete activity history.

5. Cybersecurity Quiz
- Multiple-choice cybersecurity questions.
- Immediate feedback after each answer.
- Running score tracking.
- Final score and performance summary.

6. Database Storage
The application uses SQLite with Entity Framework Core to:
- Store tasks permanently.
- Store activity log entries.
- Maintain data between application sessions.

7. Graphical User Interface
The application includes:
- Chat Interface
- Task Assistant Tab
- Quiz Tab
- Activity Log Tab

TECHNOLOGIES USED
-----------------
- C#
- WPF
- .NET
- SQLite
- Entity Framework Core
- XAML

PROJECT STRUCTURE
-----------------

Models
- TaskItem
- QuizQuestion
- ActivityLogEntry
- MessageItem

Services
- TaskManager
- TaskStorageHelper
- ActivityLogger
- QuizManager

Data Layer
- ApplicationDbContext

User Interface
- MainWindow.xaml
- MainWindow.xaml.cs

HOW TO RUN THE APPLICATION
--------------------------
1. Open the solution in Visual Studio.
2. Restore all NuGet packages.
3. Build the solution.
4. Ensure the following files are available:
   - Greeting.wav
   - Application images
5. Run the project using:
   - F5 (Start Debugging)
   - Ctrl + F5 (Start Without Debugging)

SAMPLE USER COMMANDS
--------------------

Cybersecurity Questions
- What is phishing?
- Explain malware.
- Tell me about ransomware.
- What is 2FA?
- Why is privacy important?

Task Commands
- Add a task to update my passwords.
- Remind me to enable 2FA tomorrow.
- Create a task to review privacy settings.

Quiz Commands
- Start quiz
- Test my knowledge
- Quiz me

Activity Log Commands
- Show activity log
- Show recent actions
- Show more

FUTURE IMPROVEMENTS
-------------------
- Voice recognition support.
- AI-powered chatbot responses.
- Notification reminders.
- User authentication.
- Cloud database integration.
- Additional cybersecurity topics.

AUTHOR
------
Student Name: Samukelisiwe Mthombeni
Student Number: ST10493347
Module: PROG6221
Project: Cybersecurity Awareness Chatbot
Year: 2026

CONCLUSION
----------
The Cybersecurity Awareness Chatbot provides an engaging and
educational platform for learning cybersecurity concepts.
Through conversational interaction, task management, quizzes,
and activity tracking, the application promotes cybersecurity
awareness and encourages safe online behaviour.
";
    }
}