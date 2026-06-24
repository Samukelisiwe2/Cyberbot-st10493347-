    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cyberbot___st10493347_.Models;

namespace Cyberbot___st10493347_.Data
{
    public class ApplicationDbContext : DbContext
        {
        // Used to perform CRUD operations on TaskItem records.
        public DbSet<TaskItem> Tasks { get; set; } = null!;
        // Used to store and retrieve activity log entries.
        public DbSet<ActivityLogEntry> Logs { get; set; } = null!;

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
            // Only configure the context if it has not already been configured.
            if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseSqlite("Data Source=database.db");// Configure SQLite as the database provider.
                optionsBuilder.UseLazyLoadingProxies(); // Enable lazy loading for navigation properties.
            }
            }
        }
    }




