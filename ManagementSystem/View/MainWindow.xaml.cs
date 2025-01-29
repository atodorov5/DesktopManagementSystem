using ManagementSystem.Models;
using ManagementSystem.View;
using ManagementSystem.ViewModel;
using System.Windows;
using System.Windows.Controls;

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


        private void ListViewTasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = ((ListBox)sender).SelectedItem;
            _viewModel.ChangeSelectedTask((TaskEntity)selectedItem);
        }

        private void CommentsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = ((ListBox)sender).SelectedItem;
            _viewModel.ChangeSelectedComment((CommentEntity)selectedItem);
        }
    }
}