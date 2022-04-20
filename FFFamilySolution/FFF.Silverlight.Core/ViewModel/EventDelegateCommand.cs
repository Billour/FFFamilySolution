using System;   
using System.Windows.Input; 

namespace FFF.Silverlight.Core.ViewModel
{
    public class EventDelegateCommand<T>:ICommand
    {
        
        public EventDelegateCommand() : this(null, null) { }
        public EventDelegateCommand(Action<T> executeMethod) : this(executeMethod, null) { }
        public EventDelegateCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
        {
            TargetExecuteMethod = executeMethod;
            TargetCanExecuteMethod = canExecuteMethod;
        }

        public Action<T> TargetExecuteMethod { get; set; }

        public Func<T, bool> TargetCanExecuteMethod { get; set; }

        public void OnCanExecuteChanged()
        {
            this.CanExecuteChanged(this, EventArgs.Empty);
        }

        public void Execute(T parameter)
        {
            if (TargetExecuteMethod != null) TargetExecuteMethod(parameter);
        }

        public bool CanExecute(T parameter)
        {
            if (TargetCanExecuteMethod != null)
                return TargetCanExecuteMethod(parameter);
            if (TargetExecuteMethod != null)
                return true;
            return false;
        }

        

        bool ICommand.CanExecute(object parameter)
        {
            return this.CanExecute((T)parameter);
        }

        void ICommand.Execute(object parameter)
        {
            this.Execute((T)parameter);
        }

        public event EventHandler CanExecuteChanged;

        
    } 
}
    

