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
using System.Runtime.Serialization.Json;
using FFSilverlight.ViewModels;

namespace FFSilverlight
{
    public class MVVModel1: INotifyPropertyChanged
    {
        public MVVModel1()
        {
            //Show();
        }

        private Person _CurrentPerson;

        public Person CurrentPerson
        {
            get
            {
                return this._CurrentPerson;
            }
            set
            {
                if (this._CurrentPerson == value)
                {
                    return;
                }
                this._CurrentPerson = value;
                this.OnPropertyChanged("CurrentPerson");
            }
        }

        //public void Show(OpenReadCompletedEventHandler eh)
        //{
        //    WebClient client = new WebClient();
        //    string baseUrl = "http://localhost:1107/family/VVV";
        //    client.OpenReadCompleted += eh;
        //    //client.OpenReadCompleted += (s, e) =>
        //    //{

        //    //    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(string));

        //    //    this.Message = ser.ReadObject(e.Result).ToString();

        //    //};

        //    client.OpenReadAsync(new Uri(baseUrl));
        //}

        //private string message;

        //public string Message
        //{
        //    get
        //    {
        //        return this.message;
        //    }
        //    set
        //    {
        //        if (this.message == value)
        //        {
        //            return;
        //        }
        //        this.message = value;
        //        this.OnPropertyChanged("Message");
        //    }
        //}

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
