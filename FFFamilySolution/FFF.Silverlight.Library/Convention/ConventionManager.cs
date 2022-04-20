using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Convention.Convention
{
    /// <summary>
    ///     convention engine that handles wiring up views, viewmodels and
    ///     data-binding
    /// </summary>
    [Export]
    public class ConventionManager : IPartImportsSatisfiedNotification
    {
        /// <summary>
        ///     Regions
        /// </summary>
        [ImportMany]
        public Lazy<ContentControl, IRegionTagCapabilities>[] Regions { get; set; }

        /// <summary>
        ///     Views
        /// </summary>
        [ImportMany]
        public Lazy<UserControl, IControlTagCapabilities>[] Views { get; set; }

        /// <summary>
        ///     View models
        /// </summary>
        [ImportMany]
        public Lazy<Object, IVMTagCapabilities>[] ViewModels { get; set; }

        /// <summary>
        ///     When everything is available, wire it up
        /// </summary>
        public void OnImportsSatisfied()
        {
            int aa = Regions.Length;

            // iterate regions
            foreach (var regionImport in Regions)
            {
                var tag = regionImport.Metadata.Tag;

                // find the view
                var viewTag = (from v in Views where v.Metadata.Tag.Equals(tag) select v).FirstOrDefault();

                if (viewTag == null) continue;

                // find the view model
                var viewModelTag =
                    (from vm in ViewModels where vm.Metadata.Tag.Equals(tag) select vm).FirstOrDefault();

                if (viewModelTag == null) continue;

                // now bind and attach
                var view = viewTag.Value;
                _Bind(view, viewModelTag.Value);
                regionImport.Value.Content = view;
            }
        }

        /// <summary>
        ///     Convention-based binding
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="viewModel">The view model</param>
        private static void _Bind(FrameworkElement view, object viewModel)
        {
            var elements = _Elements(view.FindName("LayoutRoot") as Panel).ToList();

            // wire in buttons
            foreach (var button in (from e in elements where e is Button select e as Button).ToList())
            {
                var nameProperty = button.GetValue(FrameworkElement.NameProperty);

                // only makes sense if this exists
                if (nameProperty == null) continue;

                var name = nameProperty.ToString();

                // does a corresponding method exist?
                var actionMethod = (from m in viewModel.GetType().GetMethods()
                                    where
                                        m.Name.Equals(name)
                                    select m).FirstOrDefault();

                // good, invoke it on click
                if (actionMethod != null)
                {
                    button.Click += (o, e) => actionMethod.Invoke(viewModel, new object[] { });
                }

                // does a canxx exist? 
                var enabledProperty = (from p in viewModel.GetType().GetProperties()
                                       where
                                           p.Name.Equals("Can" + name)
                                       select p).FirstOrDefault();

                if (enabledProperty == null) continue;

                // yes, so set the enabled and then wire a property change listener
                button.IsEnabled = (bool)enabledProperty.GetGetMethod().Invoke(viewModel,
                                                                new object[] { });

                // access to modified closuer
                var button1 = button;
                ((INotifyPropertyChanged)viewModel)
                    .PropertyChanged +=
                    (o, e) =>
                    {
                        if (e.PropertyName.Equals("Can" + name))
                        {
                            button1.IsEnabled = (bool)enabledProperty.GetGetMethod()
                                                            .Invoke(viewModel, new object[] { });
                        }
                    };
            }

            // now iterate the properties
            foreach (var propertyInfo in viewModel.GetType().GetProperties())
            {
                // must have a public getter and setter
                if (propertyInfo.GetGetMethod() == null || propertyInfo.GetSetMethod() == null) continue;

                var propName = propertyInfo.Name;

                // find the corresponding element
                var element =
                    (from e in elements where propName.Equals(e.GetValue(FrameworkElement.NameProperty)) select e).
                        FirstOrDefault();

                if (element == null) continue;

                // right now we just handle the text box case
                if (element is TextBox)
                {
                    var binding = new Binding
                    {
                        Source = viewModel,
                        Path = new PropertyPath(propName),
                        Mode = BindingMode.TwoWay
                    };
                    ((TextBox)element).SetBinding(TextBox.TextProperty, binding);
                }
            }
        }

        /// <summary>
        ///     Iterates all elements in a control recursively
        /// </summary>
        /// <param name="panel">The panel</param>
        /// <returns>The panel and its children</returns>
        private static IEnumerable<UIElement> _Elements(Panel panel)
        {
            // return the panel itels
            yield return panel;

            // iterate children
            foreach (var element in panel.Children)
            {
                // if panel, recurse
                if (element is Panel)
                {
                    foreach (var child in _Elements((Panel)element))
                    {
                        yield return child;
                    }
                }
                else
                {
                    // return the element
                    yield return element;
                }
            }
        }
    }
}
