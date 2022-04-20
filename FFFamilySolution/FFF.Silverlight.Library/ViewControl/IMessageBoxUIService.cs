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

namespace FFF.Silverlight.Library.ViewControl
{
    public interface IMessageBoxUIService
    {
        GenericMessageBoxResult Show(string message, string caption, GenericMessageBoxButton buttons);
        void Show(string message, string caption);
    }
}
