
using System;
using System.Windows.Input;

namespace SampleLab.CustomCommand
{
    public class DelegateCommand<T> : ICommand
    {
        private Func<object, bool> _canExecute;
        Action<T> _executeAction;

        public DelegateCommand(Action<T> executeAction, Func<object, bool> canExecute = null)
        {
            if (executeAction == null)
            {
                throw new ArgumentNullException("executeAction should not be null");
            }

            _executeAction = executeAction;
            _canExecute = canExecute;
        }

        #region "ICommand Implemetation"

        public event EventHandler CanExecuteChanged;
        public void RaiseCanExecuteChanged()
        {
            EventHandler handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        public bool CanExecute(object parameter)
        {
            bool result = true;

            Func<object, bool> canExecuteHandler = _canExecute;
            if (canExecuteHandler != null)
            {
                result = canExecuteHandler(parameter);
            }
            return result;
        }

        public void Execute(object parameter)
        {
            T param = (T)parameter;
            _executeAction(param);
        }

        #endregion
    }
}
