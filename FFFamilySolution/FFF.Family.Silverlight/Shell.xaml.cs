using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Theming;

namespace FFF.Family.Silverlight
{
    public partial class Shell : UserControl
    {
        public Shell()
        {
            InitializeComponent();
        }

      

        private void themeselect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ResourceDictionary ReDi = new ResourceDictionary();
            //ReDi.Source = new Uri("/"+(themeselect.SelectedItem as ComboBoxItem).Tag.ToString()+";component/Theme.xaml", UriKind.RelativeOrAbsolute);

            //Application.Current.Resources.MergedDictionaries.Clear();
            //Application.Current.Resources.MergedDictionaries.Add(ReDi);


             //Uri uri = new Uri((themeselect.SelectedItem as ComboBoxItem).Tag.ToString(), UriKind.Relative);  

             //System.Windows.Controls
             //ImplicitStyleManager.SetResourceDictionaryUri(LayoutRoot, uri);  

             //ImplicitStyleManager.Apply(LayoutRoot);  

        }
    }
}
