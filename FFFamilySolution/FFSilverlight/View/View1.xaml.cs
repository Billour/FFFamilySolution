using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using FFSilverlight.ViewModels;
using Convention.Convention;
using System.ComponentModel.Composition;

namespace FFSilverlight.View
{
    public delegate void OnClickResult(object sender, EventArgs e);


    [ControlTag("Sample")]
    public partial class View1 : UserControl
    {
        //public event OnClickResult OnOkButtonClicked;

        public View1()
        {
            InitializeComponent();

            //DataContext = new VModel1();

            //this.CurrentPerson = new Person() { PersonID = "A", PersonName = "Jack" };
        }

        //public string SelectedText { get; set; }

        //public Person CurrentPerson { get; set; }

        //private void ClickMe_Click(object sender, RoutedEventArgs e)
        //{
        //    this.OnOkButtonClicked(sender, new EventArgs());
        //}

        //public string SelectedText
        //{
        //    get { return (string)GetValue(DependencyProperty.Register("SelectedText", typeof(string), typeof(View1), new PropertyMetadata("", (s, e) => { }))); }
        //    set { SetValue(DependencyProperty.Register("SelectedText", typeof(string), typeof(View1), new PropertyMetadata("", (s, e) => { })), value); }
        //}

        //public void ShowMe()
        //{
        //    lbMe.Text = this.SelectedText;

        //}

        //public static readonly DependencyProperty SelectedTextProperty = DependencyProperty.Register("SelectedText", typeof(string), typeof(View1), new PropertyMetadata("", (s, e) => { }));

        //private static void SelectedText_PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{    
        //    //empty   
        //}
    }
}
