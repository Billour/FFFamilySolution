using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using Microsoft.Practices.ServiceLocation;


namespace FFF.Silverlight.Core.ViewModel
{
    /// <summary>
    /// Class for View Model Locator Service
    /// The main purpose is to add design mode modelview
    /// </summary>
    /// <typeparam name="TViewModel"></typeparam>
    public abstract class ViewModelLocatorBase<TViewModel>:NotifyPropertyChangedEnabledBase where TViewModel:class
    {
        private static bool? isInDesignMode;
        private TViewModel runtimeViewModel;
        private TViewModel designtimeViewModel;

        /// <summary>
        /// Gets a value indicating whether the control is in design mode
        /// (running in Blend or Visual Studio).
        /// </summary>
        public static bool IsInDesignMode
        {
            get
            {
                if (!isInDesignMode.HasValue)
                {
                    isInDesignMode = DesignerProperties.IsInDesignTool;
                }

                return isInDesignMode.Value;
            }
        }

        protected TViewModel RuntimeViewModel
        {
            get
            {
                if (this.runtimeViewModel == null)
                {
                    this.RuntimeViewModel =ServiceLocator.Current.GetInstance<TViewModel>();
                }
                return runtimeViewModel;
            }

            set
            {
                runtimeViewModel = value;
                this.RaisePropertyChanged(() => this.ViewModel);
            }
        }

        public TViewModel ViewModel
        {
            get
            {
                return IsInDesignMode ? this.DesigntimeViewModel : this.RuntimeViewModel;
            }
        }

        public TViewModel DesigntimeViewModel
        {
            get
            {
                return designtimeViewModel;
            }

            set
            {
                designtimeViewModel = value;
                this.RaisePropertyChanged(() => this.ViewModel);
            }
        }
    }
}
