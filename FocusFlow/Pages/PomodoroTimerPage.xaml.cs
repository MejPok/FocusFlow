using FocusFlow.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FocusFlow.ViewModels;

namespace FocusFlow.Pages
{
    /// <summary>
    /// Interakční logika pro PomodoroTimerPage.xaml
    /// </summary>
    public partial class PomodoroTimerPage : Page
    {
        TaskItem task;
        public PomodoroTimerViewModel ViewModel { get; set; }
        public PomodoroTimerPage(TaskItem task)
        {
            this.task = task;
            InitializeComponent();
            ViewModel = new PomodoroTimerViewModel(task.Id);
            ViewModel.bar = TimerProgressBar;
            this.DataContext = ViewModel;
        }

        bool stopped;

        private void Pause(object sender, RoutedEventArgs e)
        {
            stopped = !stopped;
            if (stopped) {
                ViewModel.Timer._timer.Stop();
            } else
            {
                ViewModel.Timer._timer.Start();
            }
            
        }
        private void Skip(object sender, RoutedEventArgs e)
        {
            ViewModel.Timer.Session.SecondsPassed = ViewModel.Timer.Session.DurationMinutes * 60;
        }
    }
}
