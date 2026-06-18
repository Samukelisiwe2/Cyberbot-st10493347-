using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberbot___st10493347_.Data;
using Cyberbot___st10493347_.Models;


namespace Cyberbot___st10493347_.Services
{
        public class ActivityLogger
        {
            public ActivityLogger()
            {
                using ApplicationDbContext db = new ApplicationDbContext();
                db.Database.EnsureCreated();
            }

            public void Log(string action)
            {
                using ApplicationDbContext db = new ApplicationDbContext();
                db.Database.EnsureCreated();

                ActivityLogEntry log = new ActivityLogEntry
                {
                    Description = action,
                    CreatedAt = DateTime.Now.ToString("[HH:mm] ")
                };

                db.Logs.Add(log);
                db.SaveChanges();
            }

            public string GetRecentLog(int count = 10)
            {
                using ApplicationDbContext db = new ApplicationDbContext();
                db.Database.EnsureCreated();

                var logs = db.Logs
                    .OrderByDescending(l => l.Id)
                    .Take(count)
                    .OrderBy(l => l.Id)
                    .ToList();

                return FormatLogs(logs);
            }

            public string GetFullLog()
            {
                using ApplicationDbContext db = new ApplicationDbContext();
                db.Database.EnsureCreated();

                var logs = db.Logs
                    .OrderBy(l => l.Id)
                    .ToList();

                return FormatLogs(logs);
            }

            public int GetCount()
            {
                using ApplicationDbContext db = new ApplicationDbContext();
                db.Database.EnsureCreated();

                return db.Logs.Count();
            }

            private string FormatLogs(System.Collections.Generic.List<ActivityLogEntry> logs)
            {
                if (logs.Count == 0)
                {
                    return "No activity has been recorded yet.";
                }

                StringBuilder builder = new StringBuilder();

                builder.AppendLine("Here's a summary of recent actions:");

                for (int i = 0; i < logs.Count; i++)
                {
                    builder.AppendLine($"{i + 1}. {logs[i].CreatedAt}{logs[i].Description}");
                }

                return builder.ToString().Trim();
            }
        }
    }
