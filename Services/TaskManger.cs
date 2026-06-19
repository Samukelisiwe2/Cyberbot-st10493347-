using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Cyberbot___st10493347_.Models;

namespace Cyberbot___st10493347_.Services
{
    public class TaskManager
    {
        private readonly TaskStorageHelper _storage;
        private readonly ActivityLogger _logger;

        public TaskItem? LastAddedTask { get; private set; }

        public TaskManager(ActivityLogger logger)
        {
            _storage = new TaskStorageHelper();
            _logger = logger;
        }

        public string AddTask(string title, string description, string reminder)
        {
            TaskItem task = _storage.AddTask(title, description, reminder);

            LastAddedTask = task;

            string reminderText = string.IsNullOrWhiteSpace(reminder)
                ? "no reminder set"
                : "Reminder set for " + reminder;

            _logger.Log("Task added: '" + task.Title + "' (" + reminderText + ")");

            if (string.IsNullOrWhiteSpace(reminder))
            {
                return "Task added: '" + task.Title + "'. Would you like to set a reminder for this task?";
            }

            return "Task added: '" + task.Title + "'. Reminder set for " + reminder + ".";
        }

        public List<TaskItem> GetAllTasks()
        {
            return _storage.LoadTasks();
        }

        public string MarkAsComplete(TaskItem task)
        {
            bool updated = _storage.MarkAsComplete(task.Id);

            if (updated)
            {
                _logger.Log("Task marked complete: '" + task.Title + "'");
                return "Task marked complete: '" + task.Title + "'.";
            }

            return "I could not find that task to mark complete.";
        }

        public string DeleteTask(TaskItem task)
        {
            bool deleted = _storage.DeleteTask(task.Id);

            if (deleted)
            {
                _logger.Log("Task deleted: '" + task.Title + "'");
                return "Task deleted: '" + task.Title + "'.";
            }

            return "I could not find that task to delete.";
        }

        public string SetReminderForLastTask(string reminder)
        {
            if (LastAddedTask == null)
            {
                return "Please add a task first, then I can set a reminder.";
            }

            bool updated = _storage.UpdateReminder(LastAddedTask.Id, reminder);

            if (updated)
            {
                LastAddedTask.Reminder = reminder;
                _logger.Log("Reminder set: '" + LastAddedTask.Title + "' on " + reminder);
                return "Got it! I'll remind you " + reminder + ".";
            }

            return "I could not update the reminder for that task.";
        }
    }
}