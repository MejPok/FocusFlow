using FocusFlow.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace FocusFlow.Timers
{
    public class PomodoroTimer
    {
        public PomodoroSession Session { get; set; }

        public int TaskItemId { get; set; }

        List<PomodoroSession> sessionsForTask;

        public DispatcherTimer _timer;
        public PomodoroTimer(int taskId)
        {
            TaskItemId = taskId;

            Cycle();
        }

        public void Cycle()
        {
            GetInformationDb();
            SetUpSession();
            StartCountDown();
        }

        private void StartCountDown()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Session.SecondsPassed++;

            if (Session.SecondsPassed >= Session.DurationMinutes * 60) 
            {
                _timer.Stop();
                NextPhase();
            }
        }

        void NextPhase()
        {
            using (var DbContext = new FocusDbContext()) {
                DbContext.Sessions.Add(Session);
                DbContext.SaveChanges();
            }
            Cycle();
        }

        public void GetInformationDb()
        {
            using(var DbContext = new FocusDbContext())
            {
                sessionsForTask = DbContext.Sessions.Where(x => x.Id == TaskItemId).ToList();
            }
        }

        public void SetUpSession()
        {
            Session = new PomodoroSession()
            {
                TaskId = TaskItemId,
                DurationMinutes = 25,
                SessionType = SessionType.Work,
                StartTime = DateTime.Now,
            };

            sessionsForTask.Add(Session);

            if(sessionsForTask.Count % 8 == 0)
            {
                Session.SessionType = SessionType.LongPause;
                Session.DurationMinutes = 15;

            } else if(sessionsForTask.Count % 2 == 0)
            {
                Session.SessionType = SessionType.Pause;
                Session.DurationMinutes = 5;

            }
            

        }

    }
}
