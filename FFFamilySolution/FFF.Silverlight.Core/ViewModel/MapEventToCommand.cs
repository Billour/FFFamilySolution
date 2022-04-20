using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Markup;  

namespace FFF.Silverlight.Core.ViewModel
{
    /// <summary>
    /// Using Interactivity Trigger To Mapping Event and Command
    /// </summary>
    public class MapEventToCommand:TriggerAction<DependencyObject>
    {

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(MapEventToCommand), new PropertyMetadata(null, (o, e) => OnDependencyPropertyChangedAction(o, e, CommandProperty)));
        public static readonly DependencyProperty ArgumentProperty = DependencyProperty.Register("Argument", typeof(object), typeof(MapEventToCommand), new PropertyMetadata(null, (o, e) => OnDependencyPropertyChangedAction(o, e, ArgumentProperty)));
        public static readonly DependencyProperty IsSendObjProperty = DependencyProperty.Register("IsSendObj", typeof(bool), typeof(MapEventToCommand), null);  

        private static Action<DependencyObject, DependencyPropertyChangedEventArgs, DependencyProperty> OnDependencyPropertyChangedAction   
        {   
            get  
            {   
                return (o, e, dp) =>   
                {
                    var d = o as MapEventToCommand;   
                    if (d != null) d.SetValue(dp, e.NewValue);   
                };   
            }   
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public object Argument
        {
            get { return GetValue(ArgumentProperty); }
            set { SetValue(ArgumentProperty, value); }
        }

        public bool IsSendObj
        {
            get { return (bool)GetValue(IsSendObjProperty); }
            set { SetValue(IsSendObjProperty, value); }
        }   


        protected override void Invoke(object parameter)   
        {   
            if (this.AssociatedObject != null)   
            {   
                if (this.Command != null)   
                {
                    var eventInfo = IsSendObj ? new EventCommandObject(this.AssociatedObject, parameter as EventArgs, this.Argument)
                                                : new EventCommandObject(parameter as EventArgs, this.Argument);   
                    if (this.Command.CanExecute(eventInfo))   
                        this.Command.Execute(eventInfo);   
                }   
                else throw new ArgumentNullException("要调用的命令不存在.");   
            }   
            else throw new ArgumentNullException("附加的对象为空.");   
        }   



    }
}
