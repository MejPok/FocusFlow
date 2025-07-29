using FocusFlow.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusFlow.ViewModels
{
    public class TaskListsViewModel : INotifyPropertyChanged
    {
        public TaskListsViewModel()
        {
            ReloadItems();
        }
        public ObservableCollection<TaskItem> LoadedItems {  get; set; }


        public void ReloadItems()
        {
            using (var DbContext = new FocusDbContext())
            {
                LoadedItems = new ObservableCollection<TaskItem>(DbContext.Tasks.ToList());
                OnPropertyChanged(nameof(LoadedItems));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
