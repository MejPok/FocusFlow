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

    public class PomodoroSession
    {
        public int Id { get; set; }
        public int TaskId {  get; set; }
        public DateTime StartTime;
        public int DurationMinutes { get; set; }
        public string SessionType { get; set; }
    }

    public class TaskItem
    {
        public int Id { get; set; }
        public string Title {  get; set; }
        public string? Description { get; set; }
        public PriorityLevel Priority { get; set; }
        public bool IsDone { get; set; }


    }

    public enum PriorityLevel
    {
        Low,
        Medium,
        High
    }
}
