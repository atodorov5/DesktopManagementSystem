using ManagementSystem.DataTypes.Commands;
using ManagementSystem.DataTypes.Enums;
using ManagementSystem.Models;
using ManagementSystem.Services;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace ManagementSystem.ViewModel
{
    public class AddCommentViewModel : IAddCommentViewModel, INotifyPropertyChanged
    {
        public ICommand AddNewCommentCommand { get; private set; }
        private TaskEntity _selectedTask;

        public event PropertyChangedEventHandler? PropertyChanged;

        string _comment;
        CommentType _commentType;
        DateTime? _reminderDate;

        private readonly ICommentService _commentService;

        public AddCommentViewModel(ICommentService commentService)
        {
            AddNewCommentCommand = new RelayCommand(AddNewComment);
            DateTime DateAdded = DateTime.Now;
            string Comment = string.Empty;
            _commentService = commentService;
        }

        public string Comment 
        {
            get { return _comment; } 
            set { _comment = value; OnPropertyChanged("Comment"); } 
        }

        public CommentType CommentType
        {
            get { return _commentType; }
            set { _commentType = value; OnPropertyChanged("CommentType"); }
        }

        public DateTime? ReminderDate
        {
            get { return _reminderDate; }
            set { _reminderDate = value; OnPropertyChanged("ReminderDate"); }
        }
        public TaskEntity SelectedTask
        {
            get { return _selectedTask; }
            set { _selectedTask = value; }
        }

        private async void AddNewComment(object obj)
        {
            var newComment = new CommentEntity
            {
                DateAdded = DateTime.Now,
                Comment = _comment,
                CommentType = _commentType,
                ReminderDate = _reminderDate,
                TaskId = SelectedTask.Id
            };

            await _commentService.AddNewCommentAsync(newComment);

            // Close the window
            // TODO: find better way
            foreach (Window window in Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.Close();
                    break;
                }
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
