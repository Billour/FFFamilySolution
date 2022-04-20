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
using System.ComponentModel.Composition.Hosting;
using Microsoft.Practices.ServiceLocation;
using System.ComponentModel.Composition;
using Microsoft.Practices.Unity;
using System.Reflection;
using FFF.Silverlight.Library.ViewModel;
using FFF.Silverlight.Library.ViewControl;
using FFF.Prism.Silverlight.Views;



namespace FFF.Prism.Silverlight
{
    /// <summary>
    /// Bootstrapper in Silverlight
    /// </summary>
    public static class Bootstrapper
    {
        //public Bootstrapper()
        //{
            //Mef
            //MefServiceLocator locator = new MefServiceLocator(ConfigureMefContainer());
            //ServiceLocator.SetLocatorProvider(() => locator);
            
            // Unity Sample
            //UnityServiceLocator locator = new UnityServiceLocator(ConfigureUnityContainer());
            //ServiceLocator.SetLocatorProvider(() => locator);

            //ServiceLocatorManager.SetServiceLocator(new MefServiceLocator(ConfigureMefContainer()));
            //Unity
            //ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(ConfigureUnityContainer()));
            //Mef
            //ServiceLocator.SetLocatorProvider(() => new MefServiceLocator(ConfigureMefContainer()));
        //}

        public static void InitializeIoc()
        {
            
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(ConfigureUnityContainer()));
            //ServiceLocator.SetLocatorProvider(() => new MefServiceLocator(ConfigureMefContainer()));
        }

        private static CompositionContainer ConfigureMefContainer()
        {
            var catalog = new AggregateCatalog(     
                new AssemblyCatalog(Assembly.GetExecutingAssembly())     
            ); 
                        
            var container = new CompositionContainer(catalog);

            return container;
        }

        private static IUnityContainer ConfigureUnityContainer()
        {
            UnityContainer container = new UnityContainer();
            container.RegisterType<IMainPageViewModel,MainPageViewModel>(new ContainerControlledLifetimeManager());
            container.RegisterType<IModalDialogUIService, ModalDialogUIService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IMessageBoxUIService, MessageBoxUIService>(new ContainerControlledLifetimeManager());

            container.RegisterType<IModalWindow, EditUserModalDialogView>(Constants.EditUserModalDialog);
            return container;
        }
    }

    public interface ILogger
    { }

    [Export(typeof(ILogger))]
    [Export(typeof(SimpleLogger))]
    public class SimpleLogger : ILogger { }

    [Export(typeof(ILogger))]
    [Export(typeof(AdvancedLogger))]
    public class AdvancedLogger : ILogger { }
}
