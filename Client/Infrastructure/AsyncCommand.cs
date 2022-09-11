using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.Infrastructure
{
    public abstract class AsyncCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        protected abstract Task ExecuteCommandAsync(object parameter);

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            await ExecuteCommandAsync(parameter);
        }
    }
}
