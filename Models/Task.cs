using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskaty.Models
{
    class Task
    {
        public int Id { get; set; }

        public string Status { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string deadline { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
