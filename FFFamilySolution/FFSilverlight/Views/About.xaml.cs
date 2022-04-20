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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.IsolatedStorage;
using Convention.Convention;
using System.ComponentModel.Composition;

namespace FFSilverlight
{
    [Export(typeof(UserControl))]
    public partial class About : Page
    {
        [RegionTag("Sample")]
        public ContentControl ExampleRegion
        {
            get { return ConventionRegion; }
        }

        public About()
        {
            InitializeComponent();

            //IsolatedStorageSettings userSettings = IsolatedStorageSettings.ApplicationSettings;

            //Sample1.Text = userSettings["userImage"].ToString();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void ClickMe_Click(object sender, RoutedEventArgs e)
        {
            //PP.SelectedText = "Twice";
            
            //PP.ShowMe();
        }

        private void PP_OnOkButtonClicked(object sender, EventArgs e)
        {
            MessageBox.Show("From Child UserControl");
        }
    }
}