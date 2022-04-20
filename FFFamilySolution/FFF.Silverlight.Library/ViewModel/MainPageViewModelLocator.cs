using FFF.Silverlight.Core.ViewModel;
using FFF.Silverlight.Library.ViewModel;

namespace FFF.Silverlight.Library.ViewModel
{
    public class MainPageViewModelLocator:ViewModelLocatorBase<IMainPageViewModel>
    {
        public MainPageViewModelLocator()
        {
            this.DesigntimeViewModel = new DummyMainPageViewModel();
        }
    }
}
