using ManagementSystem.DataTypes.Commands;
using ManagementSystem.DataTypes.Enums;
using ManagementSystem.Models;
using ManagementSystem.Services;
using System.ComponentModel;
using System.Windows.Input;

namespace ManagementSystem.ViewModel
{
    public class CreateTaskViewModel : INotifyPropertyChanged, ICreateTaskViewModel
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand CreateCommand { get; private set; }

        private IUserService _userService { get; set; }
        private ITaskService _taskService { get; set; }


        DateTime _createdDate;
        DateTime _requiredByDate;
        string description;
        DataTypes.Enums.TaskStatus _status;
        TaskType _type;
        IEnumerable<UserEntity> _users = new List<UserEntity>();
        IEnumerable<UserEntity> _selectedUsers = new List<UserEntity>();

        public CreateTaskViewModel(IUserService userService, ITaskService taskService)
        {
            CreateCommand = new RelayCommand(CreateTask);
            _userService = userService;
            _taskService = taskService;
        }

        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; OnPropertyChanged("CreatedDate"); }
        }

        public DateTime RequiredByDate
        {
            get { return _requiredByDate; }
            set { _requiredByDate = value; OnPropertyChanged("RequiredByDate"); }
        }
        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged("Description"); }
        }

        public DataTypes.Enums.TaskStatus Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged("Status"); }
        }
        public TaskType Type 
        { 
            get { return _type; } 
            set { _type = value; OnPropertyChanged("Type"); } 
        }

        public IEnumerable<UserEntity> Users
        {
            get { return _users; }
            set { _users = value; OnPropertyChanged("Users"); }
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
                Users = _selectedUsers,
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
            Users = allUsers;
        }

        public void ChangeSelectedUsers(IEnumerable<UserEntity> userEntities)
        {
            _selectedUsers = userEntities.ToList();
        }
    }
}
