using ManagementSystem.Models;
using System.Windows.Input;

namespace ManagementSystem.ViewModel
{
    public interface IAddCommentViewModel
    {
        ICommand AddNewCommentCommand { get; }
        TaskEntity SelectedTask { get; set; }
    }
}
