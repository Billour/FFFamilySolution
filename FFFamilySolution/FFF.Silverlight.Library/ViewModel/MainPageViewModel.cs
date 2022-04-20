using System;
using FFF.Silverlight.Core.ViewModel;
using System.Collections.ObjectModel;
using FFF.Silverlight.Entity.Model;
using System.Windows.Input;
using System.Threading;
using FFF.Silverlight.Library.ViewControl;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.ServiceLocation;


namespace FFF.Silverlight.Library.ViewModel
{
    public class MainPageViewModel:ViewModelBase,IMainPageViewModel
    {

        
         private readonly IModalDialogUIService modalDialogService;
        private readonly IMessageBoxUIService messageBoxService;
        private ObservableCollection<User> users = new ObservableCollection<User>();

        public MainPageViewModel(IModalDialogUIService modalDialogService, IMessageBoxUIService messageBoxService)
        {
          this.modalDialogService = modalDialogService;
          this.messageBoxService = messageBoxService;

          this.Users = new ObservableCollection<User>();

          for (int i = 1; i < 6; i++ )
          {
            this.Users.Add(new User {Username = string.Format("Admin User {0}", new Random((int)DateTime.Now.Ticks).Next(10,100)), IsAdmin = true});
            Thread.Sleep(100);
          }

          this.ShowUserCommand = 
              new DelegateCommand<User>(userInstanceToEdit =>
                                      {
                                         var dialog =ServiceLocator.Current.GetInstance<IModalWindow>(Constants.EditUserModalDialog);
                                         this.modalDialogService.ShowDialog(dialog, new EditUserModalDialogViewModel
                                                                            {
                                                                              User = userInstanceToEdit
                                                                            },

                                                                            returnedViewModelInstance =>
                                                                            {
                                                                              if (dialog.DialogResult.HasValue && dialog.DialogResult.Value)
                                                                              {
                                                                                var oldPos = this.Users.IndexOf(userInstanceToEdit);
                                                                                this.Users.RemoveAt(oldPos);
                                                                                this.Users.Insert(oldPos, returnedViewModelInstance.User);
                                                                              }
                                                                            });
                                       });
          
          this.DeleteUserCommand = new DelegateCommand<User>(p =>
                                                               {
                                                                 var result = this.messageBoxService.Show(string.Format("Are you sure you want to delete user {0} ???", p.Username),
                                                                     "Please Confirm", GenericMessageBoxButton.OkCancel);
                                                                 if (result == GenericMessageBoxResult.Ok)
                                                                 {
                                                                   this.Users.Remove(p);
                                                                 }});


        }

        public ObservableCollection<User> Users
        {
            get { return users; }
            set { users = value;
            this.RaisePropertyChanged(()=>this.Users);
            }
        }

        private ICommand showUserCommand;
        public ICommand ShowUserCommand
        {
            get { return showUserCommand; }
            set { showUserCommand = value;
                this.RaisePropertyChanged(()=>this.ShowUserCommand);
            }
        }

      private ICommand deleteUserCommand;
      public ICommand DeleteUserCommand
      {
          get { return deleteUserCommand; }
          set
          {
              deleteUserCommand = value;
              this.RaisePropertyChanged(() => this.DeleteUserCommand);
          }
      }
        
    }
}
