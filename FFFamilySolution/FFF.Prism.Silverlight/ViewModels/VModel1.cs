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
using System.ComponentModel;
using Microsoft.Practices.Prism.Commands;

namespace FFF.Prism.Silverlight.ViewModels
{
    public class VModel1:INotifyPropertyChanged
    {
        
        private string _InputName;
        private Person _Person;

        public VModel1()
        {
            this.InputName = "One";
            this.Person = new ViewModels.Person() { PersonID = "Jack", PersonName = "Lady" };

            SubmitMethod = new DelegateCommand<object>(o => {
                //this.InputName = "Command Is OK";
                MessageBox.Show(this.InputName);
            });

            SavePersonCommand = new DelegateCommand<object>(o =>
            {

                MessageBox.Show(this.Person.PersonName);

            });
        }

        public string InputName
        {
            get { return _InputName; }
            set {
                _InputName = value;
                this.RaisePropertyChanged("InputName");
            }
        }

        public Person Person
        {
            get { return _Person; }
            set {
                _Person = value;
                this.RaisePropertyChanged("Person");
            }
        }


        public DelegateCommand<object> SubmitMethod { get; set; }

        public DelegateCommand<object> SavePersonCommand { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class Person
    {
        public string PersonID { get; set; }

        public string PersonName { get; set; }
    }
}
