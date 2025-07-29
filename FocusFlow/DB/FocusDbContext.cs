using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusFlow.DB
{
    internal class FocusDbContext : DbContext
    {
        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<PomodoroSession> Sessions { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Use SQLite, specify your DB file path
            optionsBuilder.UseSqlite("Data Source=focusflow.db");
        }
    }
}
