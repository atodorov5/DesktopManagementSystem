using ManagementSystem.View;
using ManagementSystem.ViewModel;
using System.Windows;

namespace ManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        IMainViewModel _viewModel;

        public MainWindow(IMainViewModel mainViewModel)
        {
            InitializeComponent();
            _viewModel = mainViewModel;
            DataContext = _viewModel;
        }

        private async void AllTasksGrid_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.GetTasks();
        }
    }
}