using ManagementSystem.DataTypes.Commands;
using ManagementSystem.DataTypes.Enums;
using ManagementSystem.Models;
using ManagementSystem.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace ManagementSystem.ViewModel
{
    public class CreateTaskViewModel : INotifyPropertyChanged, ICreateTaskViewModel
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand CreateCommand { get; private set; }

        private IUserService _userService { get; set; }
        private ITaskService _taskService { get; set; }


        DateTime createdDate;
        DateTime requiredByDate;
        string description;
        DataTypes.Enums.TaskStatus status;
        TaskType type;
        ObservableCollection<UserEntity> users = [];

        public CreateTaskViewModel(IUserService userService, ITaskService taskService)
        {
            CreateCommand = new RelayCommand(CreateTask);
            _userService = userService;
            _taskService = taskService;
        }

        public DateTime CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; OnPropertyChanged("CreatedDate"); }
        }

        public DateTime RequiredByDate
        {
            get { return requiredByDate; }
            set { requiredByDate = value; OnPropertyChanged("RequiredByDate"); }
        }
        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged("Description"); }
        }

        public DataTypes.Enums.TaskStatus Status
        {
            get { return status; }
            set { status = value; OnPropertyChanged("Status"); }
        }
        public TaskType Type 
        { 
            get { return type; } 
            set { type = value; OnPropertyChanged("Type"); } 
        }

        public ObservableCollection<UserEntity> Users
        {
            get { return users; }
            set { users = value; OnPropertyChanged("Users"); }
        }

        private async void CreateTask(object obj)
        {
            var newTask = new TaskEntity
            {
                CreatedDate = CreatedDate,
                RequiredByDate = RequiredByDate,
                Description = Description,
                Status = Status,
                Type = Type,
                Users = Users //TODO Only selected users
            };

            await _taskService.AddTaskAsync(newTask);
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public async Task LoadUsers()
        {
            var allUsers = await _userService.GetUsersAsync();
            Application.Current.Dispatcher.Invoke(() =>
            {
                Users.Clear();
                foreach (var task in allUsers)
                {
                    Users.Add(task);
                }
            });
        }
    }
}
