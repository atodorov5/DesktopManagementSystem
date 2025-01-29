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
        private readonly ICommentService _commentService;
        private ICreateTaskViewModel _createTaskViewModel;
        private IAddCommentViewModel _addCommentViewModel;


        ObservableCollection<TaskEntity> _tasks = new ObservableCollection<TaskEntity>();
        private TaskEntity _selectedTask;
        private CommentEntity _selectedComment;

        public MainViewModel(ITaskService taskService, ICreateTaskViewModel createTaskViewModel,
            ICommentService commentService, IAddCommentViewModel addCommentViewModel)
        {
            _taskService = taskService;
            _commentService = commentService;
            _createTaskViewModel = createTaskViewModel;
            OpenAddNewCommand = new RelayCommand(OpenAddNewTask);
            AddNewCommentCommand = new RelayCommand(AddNewComment);
            RemoveCommentCommand = new RelayCommand(RemoveComment);
            _addCommentViewModel = addCommentViewModel;
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

        private void OpenAddNewTask(object obj)
        {
            var addTaskWindow = new CreateTaskView(_createTaskViewModel);
            addTaskWindow.Show();
        }

        private void AddNewComment(object obj)
        {
            if (SelectedTask != null)
            {
                _addCommentViewModel.SelectedTask = SelectedTask;
                var addCommentWindow = new AddCommentView(_addCommentViewModel);
                addCommentWindow.Show();
            }
            else
            {
                MessageBox.Show("Please first select task!",
                    "Task not selected",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        private async void RemoveComment(object obj)
        {
            if (SelectedTask != null) // task and comment is selected
            {
                //remove the selected comment
                await _commentService.RemoveCommentAsync(_selectedComment.Id);
               
            }
            else
            {
                MessageBox.Show("Please first select task and comment!",
                    "Comment not selected",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        public async Task GetTasks()
        {
            var allTasks = await _taskService.GetAllTasksAsync();
            AllTasks = new ObservableCollection<TaskEntity>(allTasks);
        }

        public async void ChangeSelectedTask(TaskEntity taskEntity)
        {
            var task = await _taskService.GetTaskWithCommentsAsync(taskEntity.Id);
            SelectedTask = task;
        }
        public void ChangeSelectedComment(CommentEntity commentEntity)
        {
            _selectedComment = commentEntity;
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
