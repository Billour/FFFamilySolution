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

namespace FFSilverlight.ViewModels
{
    public class Person : INotifyPropertyChanged
    {
        private string _PersinID="";
        private string _PersonName = "";


        public string PersonID { 
            get { return _PersinID; }
            set {
                if (this._PersinID == value)
                {
                    return;
                }
                this._PersinID = value;
                this.OnPropertyChanged("PersinID");
            }
        }

        public string PersonName
        {
            get { return _PersonName; }
            set
            {
                if (this._PersonName == value)
                {
                    return;
                }
                this._PersonName = value;
                this.OnPropertyChanged("PersonName");
            }
        }

        
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
