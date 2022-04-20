using System;
using Convention.Convention;
using System.ComponentModel;
using System.ComponentModel.Composition;

namespace FFSilverlight.ViewModels
{
    /// <summary>
    /// Appending VModel to View1
    /// </summary>
    [VMTag("Sample")]
    public class VModel2: INotifyPropertyChanged
    {
        public VModel2()
        {
            //this.DisplayText = "Kevin";
        }

        // bring in the submission service
       
        private string _text;
        private string _DisplayText;

        // text is bound to the can submit, so raise both properties when changed
        public string InputText
        {
            get { return _text; }
            set
            {
                _text = value;

                if (PropertyChanged == null) return;

                PropertyChanged(this, new PropertyChangedEventArgs("InputText"));
                PropertyChanged(this, new PropertyChangedEventArgs("CanSubmit"));
            }
        }

        // submit method will get called because it matches the button name
        public void Submit()
        {
            this.DisplayText = "Welcome";

            //if (CanSubmit)
            //{
                
            //}
        }

        // our convention says that "can" plus button name will manage "isEnabled"
        public bool CanSubmit
        {
            get { return !string.IsNullOrEmpty(_text); }
        }

        public string DisplayText { 
            get { return _DisplayText; }
            set {

                _DisplayText = value;

                PropertyChanged(this, new PropertyChangedEventArgs("DisplayText"));

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
