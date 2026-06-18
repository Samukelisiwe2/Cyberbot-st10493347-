using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberbot___st10493347_.Data;
using Cyberbot___st10493347_.Models;

namespace Cyberbot___st10493347_.Services
{
     public class TaskStorageHelper
        {
            public TaskStorageHelper()
            {
                using ApplicationDbContext db = new ApplicationDbContext();
                db.Database.EnsureCreated();
            }

            public List<TaskItem> LoadTasks()
            {
                using ApplicationDbContext db = new ApplicationDbContext();
                db.Database.EnsureCreated();

                return db.Tasks
                    .OrderByDescending(t => t.Id)
                    .ToList();
            }

            public TaskItem AddTask(string title, string description, string reminder)
            {
                using ApplicationDbContext db = new ApplicationDbContext();
                db.Database.EnsureCreated();

                TaskItem task = new TaskItem
                {
                    Title = title,
                    Description = description,
                    Reminder = reminder,
                    IsComplete = false,
                    CreatedAt = DateTime.Now.ToString("dd MMM yyyy HH:mm")
                };

                db.Tasks.Add(task);
                db.SaveChanges();

                return task;
            }

            public bool MarkAsComplete(int id)
            {
                using ApplicationDbContext db = new ApplicationDbContext();
                db.Database.EnsureCreated();

                TaskItem? task = db.Tasks.FirstOrDefault(t => t.Id == id);

                if (task == null)
                {
                    return false;
                }

                task.IsComplete = true;

                db.Tasks.Update(task);
                db.SaveChanges();

                return true;
            }

            public bool UpdateReminder(int id, string reminder)
            {
                using ApplicationDbContext db = new ApplicationDbContext();
                db.Database.EnsureCreated();

                TaskItem? task = db.Tasks.FirstOrDefault(t => t.Id == id);

                if (task == null)
                {
                    return false;
                }

                task.Reminder = reminder;

                db.Tasks.Update(task);
                db.SaveChanges();

                return true;
            }

            public bool DeleteTask(int id)
            {
                using ApplicationDbContext db = new ApplicationDbContext();
                db.Database.EnsureCreated();

                TaskItem? task = db.Tasks.FirstOrDefault(t => t.Id == id);

                if (task == null)
                {
                    return false;
                }

                db.Tasks.Remove(task);
                db.SaveChanges();

                return true;
            }
        }
    }
