using FocusFlow.Timers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FocusFlow.ViewModels
{
    public class PomodoroTimerViewModel : INotifyPropertyChanged
    {
        public PomodoroTimer Timer;

        public ProgressBar bar;

        public int TaskId;
        

        public int secondsPassed
        {
            get => Timer.Session.SecondsPassed;
            set => Timer.Session.SecondsPassed = value;
        }

        public string Passed { get; set; }

        public PomodoroTimerViewModel(int TaskId)
        {
            this.TaskId = TaskId;
            Timer = new PomodoroTimer(TaskId);
            if (Timer._timer != null) {
                Timer._timer.Tick += UpdateUI;
            }
        }

        void UpdateUI(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(secondsPassed));

            bar.Value = secondsPassed;
            bar.Maximum = Timer.Session.DurationMinutes * 60;



            int min = 0;
            int sec = Timer.Session.DurationMinutes * 60 - secondsPassed;

            while (sec >= 60)
            {   
                min++;
                sec -= 60;

            }


            Passed = $"{min}min {sec}s";
            OnPropertyChanged(nameof(Passed));
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
