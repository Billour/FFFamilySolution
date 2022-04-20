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
    public class ModalDialogUIService:IModalDialogUIService
    {
        public void ShowDialog<TDialogViewModel>(IModalWindow view, TDialogViewModel viewModel, Action<TDialogViewModel> onDialogClose)
        {
            view.DataContext = viewModel;
            if (onDialogClose != null)
            {
                view.Closed += (sender, e) => onDialogClose(viewModel);
            }
            view.Show();
        }

        public void ShowDialog<TDialogViewModel>(IModalWindow view, TDialogViewModel viewModel)
        {
            this.ShowDialog(view, viewModel, null);
        }
    }
}
