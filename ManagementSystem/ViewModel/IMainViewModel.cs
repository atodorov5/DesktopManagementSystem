using ManagementSystem.Models;
using System.Windows.Input;

namespace ManagementSystem.ViewModel
{
    public interface IMainViewModel
    {
        ICommand OpenAddNewCommand { get; }
        ICommand AddNewCommentCommand { get; }
        ICommand RemoveCommentCommand { get; }
        Task GetTasks();

        void ChangeSelectedTask(TaskEntity taskEntity);
    }
}
