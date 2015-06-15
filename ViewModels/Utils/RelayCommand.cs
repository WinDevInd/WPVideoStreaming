using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModels.Utils
{
    /// <summary>
    /// RelayCommand class for Handlling button click/tap from ViewModel
    /// </summary>
    public class RelayCommand : ICommand
    {

        Func<object, bool> canExecute;
        Action<object> executeAction;

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class.
        /// </summary>
        /// <param name="executeAction">Action to be perform on click or tap of button</param>
        public RelayCommand(Action<object> executeAction)
            : this(executeAction, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class.
        /// </summary>
        /// <param name="executeAction">Action to be perform on click or tap of button</param>
        /// <param name="canExecute">delagate flag to indicate weather button can execute in ctertain condition 
        /// e.g. for Disabled button it must be raise canexecute false</param>
        public RelayCommand(Action<object> executeAction, Func<object, bool> canExecute)
        {
            if (executeAction == null)
            {
                throw new ArgumentNullException("executeAction");
            }
            this.executeAction = executeAction;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Indicate that can perform action or not
        /// </summary>
        /// <param name="parameter">Parameter passed as CommandParameter</param>
        /// <returns>true if Button is enabled, false for disabled Button</returns>
        public bool CanExecute(object parameter)
        {
            bool result = true;
            Func<object, bool> canExecuteHandler = this.canExecute;
            if (canExecuteHandler != null)
            {
                result = canExecuteHandler(parameter);
            }

            return result;
        }

        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Method to indicate Command that button can invoke action or not.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            EventHandler handler = this.CanExecuteChanged;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        /// <summary>
        /// Execute the command and perform action
        /// </summary>
        /// <param name="parameter">Parameter passed as CommandParameter</param>
        public void Execute(object parameter)
        {
            this.executeAction(parameter);
        }
    }
}
