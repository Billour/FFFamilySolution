using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using FFF.Silverlight.Core.ViewModel;
using FFF.Silverlight.Entity.Model;

namespace FFF.Silverlight.Library.ViewModel
{
    public class EditUserModalDialogViewModel:ViewModelBase,IEditUserModalDialogViewModel
    {
        public EditUserModalDialogViewModel()
        {

        }

        private User user;

        public User User
        {
            get { return user; }
            set
            {
                user = value.DeepCopy();
                this.RaisePropertyChanged(()=>this.User);
            }
        }
    }
}
