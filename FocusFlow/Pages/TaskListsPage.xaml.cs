using FocusFlow.DB;
using FocusFlow.ViewModels;
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

namespace FocusFlow.Pages
{
    /// <summary>
    /// Interakční logika pro TaskListsPage.xaml
    /// </summary>
    public partial class TaskListsPage : Page
    {
        public TaskListsViewModel ViewModel { get; set; }
        public TaskListsPage()
        {
            InitializeComponent();
            ViewModel = new TaskListsViewModel();
            this.DataContext = ViewModel;
        }

        private void AddNewTask(object sender, RoutedEventArgs e)
        {
            PriorityLevel pLevel = PriorityLevel.Low;

            if (PriorityChosen.SelectedIndex == 1)
            {
                pLevel = PriorityLevel.Medium;
            }
            else if (PriorityChosen.SelectedIndex == 2) 
            {
                pLevel = PriorityLevel.High;
            }

            var newTask = new TaskItem() 
            {
                Title = TitleBox.Text,
                Description = DescBox.Text,
                Priority = pLevel
            };

            using(var DbContext = new FocusDbContext())
            {
                DbContext.Tasks.Add(newTask);
                DbContext.SaveChanges();
            }

            ViewModel.ReloadItems();
        }

        private void MarkTaskComplete(object sender, RoutedEventArgs e)
        {
            TaskItem item = (TaskItem)TaskList.SelectedItem;
            using (var DbContext = new FocusDbContext()) {
                var foundItem = DbContext.Tasks.First(x => x.Id == item.Id);
                foundItem.IsDone = !foundItem.IsDone;

                DbContext.SaveChanges();
                ViewModel.ReloadItems();
            }
        }

        private void StartTimer(object sender, RoutedEventArgs e)
        {
            if(TaskList.SelectedItem != null)
            {   
                TaskItem item = (TaskItem)TaskList.SelectedItem;
                NavigationService.Navigate(new PomodoroTimerPage(item));
            }
            
        }
    }
}
