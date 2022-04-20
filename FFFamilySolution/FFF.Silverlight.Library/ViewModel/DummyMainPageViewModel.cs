
using FFF.Silverlight.Core.ViewModel;
using System.Collections.ObjectModel;
using FFF.Silverlight.Entity.Model;
using System.Windows.Input;

namespace FFF.Silverlight.Library.ViewModel
{
    public class DummyMainPageViewModel:ViewModelBase,IMainPageViewModel
    {
        private static ObservableCollection<User> _Users = new ObservableCollection<User>();

        public DummyMainPageViewModel()
        {
            Users = new ObservableCollection<User>
                     {
                       new User {Username = "Designtime User a", IsAdmin = true},
                       new User {Username = "Designtime User b", IsAdmin = true},
                       new User {Username = "Designtime Admin User c", IsAdmin = true},
                       new User {Username = "Designtime Admin User d", IsAdmin = true}
                     };
        }


        public ICommand ShowUserCommand
        {
            get;
            private set;

        }

        public ICommand DeleteUserCommand
        {
            get;
            private set;
        }

        public ObservableCollection<User> Users
        {
            get { return _Users; }
            set { 
                
                _Users=value;
                this.RaisePropertyChanged(() => this.Users);
             }
        }

       
    }
}
