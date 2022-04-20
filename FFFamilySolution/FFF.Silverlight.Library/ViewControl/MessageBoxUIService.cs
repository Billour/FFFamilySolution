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
    /// <summary>
    /// Message Box UI Service
    /// Show Message Box
    /// </summary>
    public class MessageBoxUIService:IMessageBoxUIService
    {
        public GenericMessageBoxResult Show(string message, string caption, GenericMessageBoxButton buttons)
        {
            var slButtons = buttons == GenericMessageBoxButton.Ok
                              ? MessageBoxButton.OK
                              : MessageBoxButton.OKCancel;

            var result = MessageBox.Show(message, caption, slButtons);

            return result == MessageBoxResult.OK ? GenericMessageBoxResult.Ok : GenericMessageBoxResult.Cancel;
        }

        public void Show(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButton.OK);
        }
    }
}
