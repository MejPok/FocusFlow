using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FocusFlow.DB;
using FocusFlow.Pages;

namespace FocusFlow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FocusDbContext Context { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new TaskListsPage());
        }
    }
}