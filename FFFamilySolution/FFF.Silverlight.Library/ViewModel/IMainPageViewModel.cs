using System.Collections.ObjectModel;
using System.Windows.Input;
using FFF.Silverlight.Entity.Model;


namespace FFF.Silverlight.Library.ViewModel
{
    public interface IMainPageViewModel
    {
        ICommand ShowUserCommand
        {
            get;
        }
        ICommand DeleteUserCommand
        {
            get;
        }

        ObservableCollection<User> Users
        {
            get;
            set;
        }
    }
}
