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
        public ICommand AddNewCommentCommand { get; private set; }
        public ICommand RemoveCommentCommand { get; private set; }

        private readonly ITaskService _taskService;
        private ICreateTaskViewModel _createTaskViewModel;


        ObservableCollection<TaskEntity> _tasks = new ObservableCollection<TaskEntity>();
        private TaskEntity _selectedTask;

        public MainViewModel(ITaskService taskService, ICreateTaskViewModel createTaskViewModel)
        {
            _taskService = taskService;
            _createTaskViewModel = createTaskViewModel;
            OpenAddNewCommand = new RelayCommand(OpenAddNew);
            AddNewCommentCommand = new RelayCommand(AddNewComment);
            RemoveCommentCommand = new RelayCommand(RemoveComment);
        }

        public ObservableCollection<TaskEntity> AllTasks
        {
            get { return _tasks; }
            set { _tasks = value; OnPropertyChanged("AllTasks"); }
        }

        public TaskEntity SelectedTask
        {
            get { return _selectedTask; }
            set { _selectedTask = value; OnPropertyChanged("SelectedTask"); }
        }


        private void OpenAddNew(object obj)
        {
            var mainWindow = new CreateTaskView(_createTaskViewModel);
            mainWindow.Show();
        }

        private void AddNewComment(object obj)
        {

        }

        private void RemoveComment(object obj)
        {

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

        public async void ChangeSelectedTask(TaskEntity taskEntity)
        {
            var task = await _taskService.GetTaskWithCommentsAsync(taskEntity.Id);
            SelectedTask = task;
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
