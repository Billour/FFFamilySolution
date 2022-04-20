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
using Microsoft.Practices.Prism.ViewModel;

namespace FFSilverlight.ViewModels
{
    /// <summary>
    /// For View1 
    /// </summary>
    public class VModel1:NotificationObject
    {
        private Person _CurrentPerson;

        public VModel1()
        {
            this.CurrentPerson = new Person() { PersonID = "B", PersonName = "Bin" };
        }

        public Person CurrentPerson {
            get { return _CurrentPerson; }
            private set {
                _CurrentPerson = value;
                this.RaisePropertyChanged(() => this.CurrentPerson);
            }
        }
    }
}
