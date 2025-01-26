using ManagementSystem.DataTypes.Commands;
using ManagementSystem.Models;
using ManagementSystem.Services;
using ManagementSystem.View;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace ManagementSystem.ViewModel
{
    public class MainViewModel : IMainViewModel, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand OpenAddNewCommand { get; private set; }

        private readonly ITaskService _taskService;
        private ICreateTaskViewModel _createTaskViewModel;


        ObservableCollection<TaskEntity> _tasks = new ObservableCollection<TaskEntity>();

        public MainViewModel(ITaskService taskService, ICreateTaskViewModel createTaskViewModel)
        {
            _taskService = taskService;
            OpenAddNewCommand = new RelayCommand(OpenAddNew);
            _createTaskViewModel = createTaskViewModel;
        }

        public ObservableCollection<TaskEntity> AllTasks
        {
            get { return _tasks; }
            set { _tasks = value; OnPropertyChanged("AllTasks"); }
        }

        private void OpenAddNew(object obj)
        {
            var mainWindow = new CreateTaskView(_createTaskViewModel);
            mainWindow.Show();
        }

        public async Task GetTasks()
        {
            var allTasks = await _taskService.GetAllTasksAsync();
            Application.Current.Dispatcher.Invoke(() =>
            {
                AllTasks.Clear();
                foreach (var task in allTasks)
                {
                    AllTasks.Add(task);
                }
            });
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
