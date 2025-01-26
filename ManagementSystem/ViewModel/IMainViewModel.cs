using System.Windows.Input;

namespace ManagementSystem.ViewModel
{
    public interface IMainViewModel
    {
        ICommand OpenAddNewCommand { get; }
        Task GetTasks();
    }
}
