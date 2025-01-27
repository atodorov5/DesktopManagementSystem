using ManagementSystem.Models;
using ManagementSystem.ViewModel;
using System.Windows;
using System.Windows.Controls;

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

        private  void ListboxUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listSelectedItems = ((ListBox)sender).SelectedItems;
            var selected = listSelectedItems.Cast<UserEntity>().ToList();
            _createTaskView.ChangeSelectedUsers(selected);
        }
    }
}
