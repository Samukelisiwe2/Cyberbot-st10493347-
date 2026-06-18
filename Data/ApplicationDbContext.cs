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
            public DbSet<TaskItem> Tasks { get; set; } = null!;
            public DbSet<ActivityLogEntry> Logs { get; set; } = null!;

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseSqlite("Data Source=database.db");
                    optionsBuilder.UseLazyLoadingProxies();
                }
            }
        }
    }




