using ManagementSystem.ViewModel;
using System.Windows;

namespace ManagementSystem.View
{
    /// <summary>
    /// Interaction logic for CreateTaskView.xaml
    /// </summary>
    public partial class CreateTaskView : Window
    {
        ICreateTaskViewModel _createTaskView;
        public CreateTaskView(ICreateTaskViewModel createTaskViewModel)
        {
            InitializeComponent();
            _createTaskView = createTaskViewModel;
            DataContext = createTaskViewModel;
        }

        private async void AllUsersGrid_Loaded(object sender, RoutedEventArgs e)
        {
            await _createTaskView.LoadUsers();
        }
    }
}
