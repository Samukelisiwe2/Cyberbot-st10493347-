using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberbot___st10493347_.Models
{
        public class ActivityLogEntry
        {
        // Unique identifier for the activity log entry.
        public int Id { get; set; }
        // Description of the activity or event that occurred.
        public string Description { get; set; } = "";
        // Date and time when the activity was created.
        public string CreatedAt { get; set; } = "";
        }
    }