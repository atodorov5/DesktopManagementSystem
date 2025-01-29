using ManagementSystem.ViewModel;
using System.Windows;

namespace ManagementSystem.View
{
    /// <summary>
    /// Interaction logic for AddCommentView.xaml
    /// </summary>
    public partial class AddCommentView : Window
    {
        IAddCommentViewModel _addCommentViewModel;

        public AddCommentView(IAddCommentViewModel addCommentViewModel)
        {
            InitializeComponent();
            _addCommentViewModel = addCommentViewModel;
            DataContext = addCommentViewModel;
        }
    }
}
