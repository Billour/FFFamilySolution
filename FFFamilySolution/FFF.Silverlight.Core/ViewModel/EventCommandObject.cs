using System;
using System.Windows;

namespace FFF.Silverlight.Core.ViewModel
{
    public class EventCommandObject
    {
        public EventCommandObject(EventArgs e, object argument)   
        {   
            this.EventArgs = e;   
            this.Argument = argument;   
        }

        public EventCommandObject(object o, EventArgs e, object argument)   
        {   
            this.Sender = o;   
            this.EventArgs = e;   
            this.Argument = argument;   
        }   
  
        public object Sender { get; private set; }   
        public EventArgs EventArgs { get; private set; }   
        public object Argument { get; set; }   
  
        public T GetSender<T>() where T : DependencyObject   
        {   
            return Sender as T;   
        }   
  
        public T GetEventArgs<T>() where T : EventArgs   
        {   
            return EventArgs as T;   
        }   
  
        public T GetArgument<T>()   
        {   
            return (T)Argument;   
        }  


    }
}
