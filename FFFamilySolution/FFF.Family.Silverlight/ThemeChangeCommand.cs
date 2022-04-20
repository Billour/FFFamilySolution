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
using System.Windows.Controls.Theming;

namespace FFF.Family.Silverlight
{
    public class ThemeChangeCommand:ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            Theme themeContainer = (Theme)((FrameworkElement)Application.Current.RootVisual).FindName("ThemeContainer");

            string themeName = parameter as string;


            if (themeName == null)
            {
                themeContainer.ThemeUri = null;
            }
            else
            {
                themeContainer.ThemeUri = new Uri("/System.Windows.Controls.Theming." + themeName + ";component/Theme.xaml", UriKind.RelativeOrAbsolute);
            }

            if (CanExecuteChanged != null)
                CanExecuteChanged(this, new EventArgs());
        }
    }
}
