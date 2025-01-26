using System.Windows.Input;

namespace ManagementSystem.ViewModel
{
    public interface ICreateTaskViewModel
    {
        ICommand CreateCommand { get; }
        Task LoadUsers();
    }
}
